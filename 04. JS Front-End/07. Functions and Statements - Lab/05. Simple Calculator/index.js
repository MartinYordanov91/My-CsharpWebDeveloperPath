function calculator(a, b, operant) {
  const operators = {
    multiply: (a, b) => a * b,
    divide: (a, b) => a / b,
    add: (a, b) => a + b,
    subtract: (a, b) => a - b,
  };

  console.log(operators[operant](a, b));
}

calculator(5, 5, "multiply");
calculator(40, 8, "divide");
calculator(12, 19, "add");
calculator(50, 13, "subtract");
