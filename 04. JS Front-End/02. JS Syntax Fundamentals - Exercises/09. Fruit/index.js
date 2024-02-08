function bayFruit(typeOfFruit, weightAtGrams, price) {
  const kilograms = (weightAtGrams / 1000).toFixed(2);
  const moneyNead = ((weightAtGrams / 1000) * price).toFixed(2);

  console.log(
    `I need $${moneyNead} to buy ${kilograms} kilograms ${typeOfFruit}.`
  );
}

bayFruit("orange", 2500, 1.8);
bayFruit("apple", 1563, 2.35);
