function deleteByEmail() {
  const outputAreaElement = document.getElementById("result");
  const inputAreaElement = document.querySelector("input[type =text]");
  const parentTableElement = document.querySelectorAll(
    "tbody tr td:nth-child(2)"
  );
  let flag = false;

  Array.from(parentTableElement).forEach((e) => {
    if (inputAreaElement.value === e.textContent) {
      const trElement = e.parentNode;
      trElement.remove();
      flag = true;
    }
  });

  outputAreaElement.textContent = flag ? "Deleted" : "Not found.";
}
