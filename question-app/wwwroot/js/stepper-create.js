const createSurvayBodyId = 'question-list';
const attrStep = 'data-step';
const attrStepTitle = 'data-step-title';
const nextButtonId = 'next-button';
const prevButtonId = 'prev-button';
const addQuestionButtonId = 'add-question';
const saveQuestionsButtonId = 'save-button';
let questionAdded = [];
let index = 0;

function onNextStep(idStep, idNextStep) {
  let step = document.getElementById(idStep);
  let nextStep = document.getElementById(idNextStep);

  if (nextStep == null || step == null) {
    alert('Step not found');
    return;
  }

  step.style.display = 'none';
  nextStep.style.display = 'block';

  // add animation transition between steps
  nextStep.classList.add('animate__animated');
  nextStep.classList.add('animate__fadeIn');
}

function deleteQuestion(index) {
  let question = document.getElementById(`question-${index}`);
  question.remove();
  questionAdded = questionAdded.filter((q) => q.index !== index);
}

// document on ready vanilla js
document.addEventListener('DOMContentLoaded', function () {
  const nextButton = document.getElementById(nextButtonId);
  const prevButton = document.getElementById(prevButtonId);
  const addQuestionButton = document.getElementById(addQuestionButtonId);

  if (nextButton == null || prevButton == null) {
    alert('Next or Prev button not found');
    return;
  }

  nextButton.addEventListener('click', function () {
    let step = document.querySelector(
      `[${attrStep}]:not([style*="display: none"])`,
    );

    if (step == null) {
      alert('Step not found');
      return;
    }

    let nextStep = step.nextElementSibling;

    if (nextStep == null) {
      alert('Next step not found');
      return;
    }

    onNextStep(step.id, nextStep.id);
  });

  prevButton.addEventListener('click', function () {
    let step = document.querySelector(
      `[${attrStep}]:not([style*="display: none"])`,
    );

    if (step == null) {
      alert('Step not found');
      return;
    }

    let prevStep = step.previousElementSibling;

    if (prevStep == null) {
      alert('Prev step not found');
      return;
    }

    step.style.display = 'none';
    prevStep.style.display = 'block';

    // add animation transition between steps
    prevStep.classList.add('animate__animated');
    prevStep.classList.add('animate__fadeIn');
  });

  if (addQuestionButton == null) {
    alert('Add question button not found');
    return;
  }

  addQuestionButton.addEventListener('click', function () {
    let step = document.getElementById(createSurvayBodyId);

    if (step == null) {
      alert('Step not found');
      return;
    }

    let question = document.createElement('div');

    question.classList.add('question');
    question.innerHTML = `
                <div id="question-${index}" class="question">
            <div class="row">
                <div class="col-5">
                    <div class="form-group">
                        <label for="title-${index}">Question</label>
                        <input type="text" class="form-control" name="title-${index}" />
                    </div>
                </div>
                <div class="col-3">
                    <div class="form-group">
                        <label for="type-${index}">Type</label>
                        <select class="form-control custom-select custom-select-sm" id="type-${index}">
                            <option value="text" selected>Text</option>
                            <option value="number">Number</option>
                            <option value="date">Date</option>
                        </select>
                    </div>
                </div>
                <div class="col-2 align-content-center pt-4">
                    <div class="form-check">
                        <input class="form-check-input" type="checkbox" value="" id="is-required-${index}">
                        <label class="form-check-label" for="is-required-${index}">
                            Is required?
                        </label>
                    </div>
                </div>
                <div class="col-2 align-content-center pt-4">
                    <button onClick="deleteQuestion(${index})" class="btn btn-danger btn-sm" data-question="${index}" type="button">X</button>
                </div>
                <div class="dropdown-divider mt-4"></div>
            </div>
        </div>`;
    step.appendChild(question);
    questionAdded.push({ index: index, question: question });
    index++;
  });

  const saveQuestionsButton = document.getElementById(saveQuestionsButtonId);

  if (saveQuestionsButton == null) {
    alert('Save button not found');
    return;
  }

  saveQuestionsButton.addEventListener('click', function () {
    const survayTitle = document.getElementById('survay-title').value;
    const survayDescription =
      document.getElementById('survay-description').value;

    if (survayTitle == null || survayTitle == '') {
      alert('Please enter the survay title');
      return;
    }

    // display alert to ask user if he want to save the questions
    let result = confirm('Are you sure you want to save the questions?');
    if (!result) {
      return;
    }

    if (questionAdded.length == 0) {
      alert('Please add at least one question');
      return;
    }

    let questions = [];

    questionAdded.forEach((q) => {
      let question = q.question;
      let title = question.querySelector(
        `input[name="title-${q.index}"]`,
      ).value;
      let type = question.querySelector(`#type-${q.index}`).value;
      let isRequired = question.querySelector(
        `#is-required-${q.index}`,
      ).checked;

      questions.push({
        title: title,
        type: type,
        isRequired: isRequired,
      });
    });

    const url = `/api/survey/create`;
    const data = {
      survayTitle: survayTitle,
      survayDescription: survayDescription || '',
      questions: questions,
    };

    fetch(url, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(data)
    })
      .then( response => {
        console.log(response);
        if (response.status === 200) {
          alert('Survey created successfully');
          window.location.href = `/Question`;
        } else {
          return response.text().then((text) => {
            throw new Error(text);
          });
      }})
      .catch((error) => console.log(error));
  });
});

// on windows leave
window.onbeforeunload = function () {
  // if leave page and questions added
  if (questionAdded.length > 0) {
    return 'Are you sure you want to leave? All changes will be lost.';
  }
  // if the user say yes to leave
  index = 0;
  questionAdded = [];
  return undefined;
};
