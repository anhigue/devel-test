document.addEventListener('DOMContentLoaded', function () {
  const formLogin = document.getElementById('form-login');

  if (formLogin == null) {
    alert('Form login not found');
    return;
  }

  formLogin.addEventListener('submit', function (event) {
    
    event.preventDefault();
    
    const formData = new FormData(formLogin);
    const formProps = Object.fromEntries(formData.entries());

    console.log(formProps);

    const username = formProps.username;
    const password = formProps.password;

    if (username == null || username == '') {
      alert('Username is required');
      return;
    }

    if (password == null || password == '') {
      alert('Password is required');
      return;
    }

    const data = {
      username: username,
      password: password,
    };

    const url = '/api/auth/login';

    fetch(url, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(data),
    })
      .then((response) => {
        if (response.status === 200) {
          return response.json();
        } else {
          return response.json().then((data) => {
            throw new Error(data.error);
          });
        }
      })
      .then((data) => {
        alert('Login successful');
        window.location.href = '/Question';
      })
      .catch((error) => {
        alert(error.message);
      });
  });
});
