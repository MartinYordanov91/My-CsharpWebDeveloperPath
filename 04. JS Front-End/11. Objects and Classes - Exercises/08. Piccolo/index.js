function solve(input) {
  const parking = new Set();

  input.forEach((row) => {
    const [operation, number] = row.split(", ");
    operation === "IN" ? parking.add(number) : parking.delete(number);
  });

  if (parking.size < 1) {
    console.log("Parking Lot is Empty");
    return;
  }

  Array.from(parking.values())
    .sort((a, b) => a.localeCompare(b))
    .forEach((car) => console.log(car));
}

solve([
  "IN, CA2844AA",
  "IN, CA1234TA",
  "OUT, CA2844AA",
  "IN, CA9999TT",
  "IN, CA2866HI",
  "OUT, CA1234TA",
  "IN, CA2844AA",
  "OUT, CA2866HI",
  "IN, CA9876HH",
  "IN, CA2822UU",
]);

solve([
'IN, CA2844AA',
'IN, CA1234TA',
'OUT, CA2844AA',
'OUT, CA1234TA'
])