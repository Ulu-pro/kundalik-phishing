let tumbler = document.querySelector('.header-localization-select__info');
let dropdown = document.querySelector('.dropdown-container');
let menuShown = false;

tumbler.addEventListener('click', function () {
  if (menuShown) {
    dropdown.style.display = 'none';
    menuShown = false;
  } else {
    dropdown.style.display = 'block';
    menuShown = true;
  }
})
