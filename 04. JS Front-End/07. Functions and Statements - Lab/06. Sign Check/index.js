function positiveOrNegatiweResult(...numbers) {
  let negative = 0;
  for (const num of numbers) {
    if (num < 0) {
      negative++;
    }
  }
  negative % 2 === 0 ? console.log("Positive") : console.log("Negative");
}

positiveOrNegatiweResult(5, 12, -15);
positiveOrNegatiweResult(-6, -12, 14);
positiveOrNegatiweResult(-1, -2, -3);
positiveOrNegatiweResult(-5, 1, 1);
