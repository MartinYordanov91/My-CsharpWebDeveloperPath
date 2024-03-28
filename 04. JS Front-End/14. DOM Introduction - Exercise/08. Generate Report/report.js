function generateReport() {
  const allCheckboxes = document.querySelectorAll('input[type="checkbox"]');
  const allRolsElement = document.querySelectorAll("tbody tr");
  const outputElement = document.getElementById("output");

  const checkboxesArray = Array.from(allCheckboxes).map((checkbox) => ({
    name: checkbox.name,
    isChecked: checkbox.checked,
  }));

  const tableContentArray = Array.from(allRolsElement).reduce((acc, curent) => {
    const curentRow = Array.from(curent.querySelectorAll("td")).reduce(
      (rowAcc, cell, i) => {
        if (!checkboxesArray[i].isChecked) {
          return rowAcc;
        }

        rowAcc[checkboxesArray[i].name] = cell.textContent;
        return rowAcc;
      },
      {}
    );
    acc.push(curentRow);
    return acc;
  }, []);

  outputElement.textContent = JSON.stringify(tableContentArray, null, 2);
}
