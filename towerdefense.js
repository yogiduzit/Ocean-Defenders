var config = {
  type: Phaser.AUTO,
  parent: 'content',
  width: 640,
  height: 512,
  scene: {
    key: 'main',
    preload: preload,
    create: create,
    update: update
  }
};

var game = new Phaser.Game(config);

var graphics;
var path;

function preload() {
  // Loads the game assets like enemies and turrets
}
function create() {
  // Create the game logic here.
  
}
function update() {
  // Updates the game every frame to make sure that all the events are taken care of.
}