function solve() {
  const butonElement = document
    .querySelector("button")
    .addEventListener("click", onClick);

  const inputNumberElement = document.getElementById("input");
  const resultNumberElement = document.getElementById("result");
  const selectMenuElement = document.getElementById("selectMenuTo");
  const binaryOptionElement = document.querySelector("#selectMenuTo option");
  const hexadecimalOptionElement = document.createElement("option");

  binaryOptionElement.textContent = "Binary";
  binaryOptionElement.value = "binary";
  hexadecimalOptionElement.textContent = "Hexadecimal";
  hexadecimalOptionElement.value = "hexadecimal";
  selectMenuElement.appendChild(hexadecimalOptionElement);

  let option = {
    binary: (number) => number.toString(2),
    hexadecimal: (number) => number.toString(16).toUpperCase(),
  };

  function onClick() {
    let choised = selectMenuElement.value;
    let curentNumber = Number(inputNumberElement.value);
    console.log(curentNumber)
    resultNumberElement.value = option[choised](curentNumber);
  }
}
