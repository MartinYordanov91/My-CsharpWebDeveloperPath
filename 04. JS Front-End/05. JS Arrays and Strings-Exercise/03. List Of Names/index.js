function sortingNames(array) {
  let output = array
    .sort((a, b) => a.localeCompare(b, "bg-BG"))
    .map((element, index) => ++index + "." + element);

  console.log(output.join("\n"));
}

sortingNames(["John", "Bob", "Christina", "Ema"]);
