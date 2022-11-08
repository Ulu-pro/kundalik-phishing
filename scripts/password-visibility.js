let input = document.getElementById('password-field');
let image = document.getElementById('visibility-icon');
document.getElementById('pass-visibility-button')
    .addEventListener('click', function () {
      if (input.type === 'password') {
        input.type = 'text';
        image.setAttribute('src', '/icons/icon-hide.svg');
      } else {
        input.type = 'password';
        image.setAttribute('src', '/icons/icon-show.svg');
      }
    });