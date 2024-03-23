function calc() {
  let firstElement = document.getElementById("num1");
  let secondElement = document.getElementById("num2");
  let resultElement = document.getElementById("sum");
  resultElement.value = Number(firstElement.value) + Number(secondElement.value);
}
