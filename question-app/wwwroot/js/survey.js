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
