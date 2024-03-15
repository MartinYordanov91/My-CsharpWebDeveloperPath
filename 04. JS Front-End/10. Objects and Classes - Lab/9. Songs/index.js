function slove(input) {
  class Song {
    constructor(typeList, name, time) {
      this.typeList = typeList;
      this.name = name;
      this.time = time;
    }
  }

  let numberOfSongs = input.shift();
  let typeSong = input.pop();
  let songs = input.reduce((acc, curent) => {
    const [songType, songName, songTime] = curent.split("_");
    acc.push(new Song(songType, songName, songTime));
    return acc;
  }, []);

  if (typeSong === "all") {
    songs.forEach((element) => {
      console.log(element.name);
    });
  } else {
    songs.forEach((element) => {
      element.typeList === typeSong ? console.log(element.name) : "";
    });
  }
}

slove([
  3,
  "favourite_DownTown_3:14",
  "favourite_Kiss_4:16",
  "favourite_Smooth Criminal_4:01",
  "favourite",
]);

slove([
  4,
  "favourite_DownTown_3:14",
  "listenLater_Andalouse_3:24",
  "favourite_In To The Night_3:58",
  "favourite_Live It Up_3:48",
  "listenLater",
]);

slove([2, "like_Replay_3:15", "ban_Photoshop_3:48", "all"]);
