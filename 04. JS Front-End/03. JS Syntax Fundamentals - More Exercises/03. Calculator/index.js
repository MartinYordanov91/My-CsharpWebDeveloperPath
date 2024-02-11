function calculate(x, operant, y) {
  switch (operant) {
    case "+":
      console.log((x + y).toFixed(2));
      break;
    case "-":
      console.log((x - y).toFixed(2));
      break;
    case "/":
      console.log((x / y).toFixed(2));
      break;
    case "*":
      console.log((x * y).toFixed(2));
      break;
  }
}

calculate(5, "+", 10);
calculate(25.5, "-", 3);
