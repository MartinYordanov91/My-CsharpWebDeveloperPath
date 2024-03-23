function sumTable() {
  let numbersElement = Array.from(
    document.querySelectorAll(
      "tbody tr:not(:last-child) td:last-child:not(#sum)"
    )
  );
  let sumElement = document.getElementById("sum");

  sumElement.textContent = numbersElement.reduce((acc, num) => {
    return acc +=Number(num.textContent);
  }, 0);
}
