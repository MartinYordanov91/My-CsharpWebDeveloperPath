function addItem() {
  const menuElement = document.getElementById("menu");
  const textElement = document.getElementById("newItemText");
  const valueElement = document.getElementById("newItemValue");

  const option = document.createElement("option");
  option.textContent = textElement.value;
  option.value = valueElement.value;

  menuElement.appendChild(option);

  textElement.value = "";
  valueElement.value = "";
}
