function solve(input) {
  let heroes = input.reduce((acc, curent) => {
    const [heroName, heroLevel, itemsAsString] = curent.split(" / ");
    const itemsAsArray = itemsAsString.split(", ");
    const hero = {
      name: heroName,
      level: Number(heroLevel),
      items: [...itemsAsArray],
    };
    acc.push(hero);
    return acc;
  }, []);

  let sortedHeroes = heroes.sort((a, b) => a.level - b.level);

  sortedHeroes.forEach((element) => {
    console.log(`Hero: ${element.name}`);
    console.log(`level => ${element.level}`)
    console.log(`items => ${element.items.join(", ")}`)
  });
}

solve([
  "Isacc / 25 / Apple, GravityGun",
  "Derek / 12 / BarrelVest, DestructionSword",
  "Hes / 1 / Desolator, Sentinel, Antara",
]);
