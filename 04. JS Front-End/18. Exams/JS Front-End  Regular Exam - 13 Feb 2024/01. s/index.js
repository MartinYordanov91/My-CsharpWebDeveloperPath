function solve(params) {
  const countHero = params.shift();
  const heroes = {};

  for (let index = 0; index < countHero; index++) {
    const [name, hp, bullets] = params.shift().split(" ");

    if (!heroes[name]) {
      heroes[name] = {
        name,
        hp: Number(hp),
        bullets: Number(bullets),
      };
    }
  }

  let curentRow;
  while ((curentRow = params.shift()) !== "Ride Off Into Sunset") {
    const [comand, ...data] = curentRow.split(" - ");
    const name = data[0];

    switch (comand) {
      case "FireShot":
        const target = data[1];

        if (heroes[name].bullets > 0) {
          heroes[name].bullets--;
          console.log(
            `${name} has successfully hit ${target} and now has ${heroes[name].bullets} bullets!`
          );
        } else {
          console.log(
            `${name} doesn't have enough bullets to shoot at ${target}!`
          );
        }
        break;
      case "TakeHit":
        const damage = Number(data[1]);
        const attacker = data[2];

        if (heroes[name].hp - damage <= 0) {
          console.log(`${name} was gunned down by ${attacker}!`);
          delete heroes[name];
        } else {
          heroes[name].hp -= damage;
          console.log(
            `${name} took a hit for ${damage} HP from ${attacker} and now has ${heroes[name].hp} HP!`
          );
        }

        break;
      case "Reload":
        let reloadBulets;

        if (heroes[name].bullets >= 6) {
          console.log(`${name}'s pistol is fully loaded!`);
        } else {
          reloadBulets = 6 - heroes[name].bullets;
          heroes[name].bullets = 6;
          console.log(`${name} reloaded ${reloadBulets} bullets!`);
        }
        break;
      case "PatchUp":
        if (heroes[name].hp === 100) {
          console.log(`${name} is in full health!`);
          break;
        }

        const amount = Number(data[1]);
        let recoveryHp;

        if (heroes[name].hp + amount >= 100) {
          recoveryHp = 100 - heroes[name].hp;
        } else {
          recoveryHp = amount;
        }
        heroes[name].hp += recoveryHp;
        console.log(`${name} patched up and recovered ${recoveryHp} HP!`);
        break;
    }
  }
 
  Object.values(heroes).forEach(hero => {
    console.log(hero.name)
    console.log(`  HP: ${hero.hp}`)
    console.log(`  Bullets: ${hero.bullets}`)
  })
}

solve([
  "2",
  "Jesse 100 4",
  "Walt 100 5",
  "FireShot - Jesse - Bandit",
  "TakeHit - Walt - 30 - Bandit",
  "PatchUp - Walt - 20",
  "Reload - Jesse",
  "PatchUp - Jesse - 20",
  "Ride Off Into Sunset",
]);
