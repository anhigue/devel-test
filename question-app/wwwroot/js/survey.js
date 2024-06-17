
function publishSurvey(surveyId) {

  if (surveyId == null) {
    alert('Survey ID not found');
    return;
  }

  const url = `api/survey/publish/${surveyId}`;

  fetch(url, {
    method: 'PATCH',
    headers: {
      'Content-Type': 'application/json',
    },
  })
    .then((response) => {
      if (response.status === 200) {
        alert('Survey published successfully');
        // reload the page
        window.location.reload();
      } else {
        return response.json().then((data) => {
          throw new Error(data.error);
        });
      }
    })
    .catch((error) => {
      alert(error.message);
    });
}

function copyLink(surveyId) {
  if (surveyId == null) {
    alert('Survey ID not found');
    return;
  }

  const url = `Question/SurveyForm/${surveyId}`;
  const fullUrl = window.location.origin + '/' + url;

  navigator.clipboard.writeText(fullUrl)
    .then(() => {
      alert('Link copied to clipboard');
    })
    .catch((error) => {
      alert(error.message);
    });
}

document.addEventListener('DOMContentLoaded', function () {
  const btnLogout = document.getElementById('btn-logout');

  if (btnLogout == null) {
    alert('Button logout not found');
    return;
  }

  btnLogout.addEventListener('click', function () {
    const url = '/api/auth/logout';

    fetch(url, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
    })
      .then((response) => {
        if (response.status === 200) {
          alert('Logout successful');
          window.location.href = '/Home';
        } else {
          return response.json().then((data) => {
            throw new Error(data.error);
          });
        }
      })
      .catch((error) => {
        alert(error.message);
      });
  });
});
