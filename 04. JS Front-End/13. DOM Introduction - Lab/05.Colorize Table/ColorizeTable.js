function colorize() {
  let tableRows = Array.from(
    document.querySelectorAll("table tr:nth-child(even)")
  );

  tableRows.forEach((row) => (row.style.background = "Teal"));
}
