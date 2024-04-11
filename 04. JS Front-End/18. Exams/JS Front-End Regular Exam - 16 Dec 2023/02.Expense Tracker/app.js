window.addEventListener("load", solve);

function solve() {
  const inputExpenseElement = document.getElementById("expense");
  const inputAmountElement = document.getElementById("amount");
  const inputDateElement = document.getElementById("date");
  const buttonAddElement = document.getElementById("add-btn");
  const buttonDelateElement = document.querySelector("#expenses button");
  const listPreviewElement = document.getElementById("preview-list");
  const listExpensesElement = document.getElementById("expenses-list");

  buttonAddElement.addEventListener("click", () => {
    let expense = inputExpenseElement.value;
    let amount = inputAmountElement.value;
    let date = inputDateElement.value;
    if (!expense || !amount || !date) {
      return;
    }
    createAndAppendLi(expense, amount, date);

    buttonAddElement.disabled = true;
    inputExpenseElement.value = "";
    inputAmountElement.value = "";
    inputDateElement.value = "";
  });

  buttonDelateElement.addEventListener("click", () => {
    location.reload();
    // listExpensesElement.innerHTML = "";
    // listPreviewElement.innerHTML = "";
    // buttonAddElement.disabled = false;
  });

  function createAndAppendLi(expense, amount, date) {
    const liElement = document.createElement("li");
    liElement.classList.add("expense-item");

    const articleElement = document.createElement("article");

    const pExpenseElement = document.createElement("p");
    pExpenseElement.textContent = `Type: ${expense}`;

    const pAmountElement = document.createElement("p");
    pAmountElement.textContent = `Amount: ${amount}$`;

    const pDateElement = document.createElement("p");
    pDateElement.textContent = `Date: ${date}`;

    const divElement = document.createElement("div");
    divElement.classList.add("buttons");

    const buttonEditElement = document.createElement("button");
    buttonEditElement.classList.add("btn", "edit");
    buttonEditElement.textContent = "edit";

    buttonEditElement.addEventListener("click", () => {
      listPreviewElement.removeChild(liElement);
      buttonAddElement.disabled = false;
      inputExpenseElement.value = expense;
      inputAmountElement.value = amount;
      inputDateElement.value = date;
    });

    const buttonOkElement = document.createElement("button");
    buttonOkElement.classList.add("btn", "ok");
    buttonOkElement.textContent = "ok";

    buttonOkElement.addEventListener("click", () => {
      listExpensesElement.appendChild(liElement);
      liElement.removeChild(divElement);
      buttonAddElement.disabled = false;
    });

    listPreviewElement.appendChild(liElement);
    liElement.appendChild(articleElement);
    liElement.appendChild(divElement);
    articleElement.appendChild(pExpenseElement);
    articleElement.appendChild(pAmountElement);
    articleElement.appendChild(pDateElement);
    divElement.appendChild(buttonEditElement);
    divElement.appendChild(buttonOkElement);
  }
}
