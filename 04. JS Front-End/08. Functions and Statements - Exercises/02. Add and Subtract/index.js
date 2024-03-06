function sumAndSubtract(a, b, c) {
  const sumNum = (a, b) => a + b;
  const subtractNum = (a, b) => a - b;

  console.log(subtractNum(sumNum(a, b), c));
}

sumAndSubtract(23, 6, 10);
sumAndSubtract(1, 17, 30);
sumAndSubtract(42, 58, 100);
