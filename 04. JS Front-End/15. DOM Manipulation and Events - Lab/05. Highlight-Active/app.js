function focused() {
  const inputsElements = Array.from(
    document.querySelectorAll("input[type=text]")
  );

  function focusElement(e) {
    e.target.parentNode.classList.add("focused");
  }

  function blurElement(e) {
    e.target.parentNode.classList.remove("focused");
  }

  inputsElements.forEach((element) => {
    element.addEventListener(`focus`, focusElement);
    element.addEventListener(`blur`, blurElement);
  });
}
