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

/** 
 * Loads the game assets like enemies and turrets
 */ 
function preload() {
  
  // Loads the atlas/directory of all the available sprites along with their JSON attributes.
  this.load.atlas('sprites', 'assets/spritesheet.png', 'assets/spritesheet.json');

  //Loads an image which can be reference by the name 'bullet'
  this.load.image('bullet', 'assets/bullet.png');
}

/**
 * Create the game logic here.
 */
function create() {
  var graphics = this.add.graphics();

  path = this.add.path(96, -32);
  path.lineTo(96, 164);
  path.lineTo(480, 164);
  path.lineTo(480, 544);

  graphics.lineStyle(3, 0xffffff, 1);

  path.draw(graphics);
}
/**
 * Updates the game every frame to make sure that all the events are taken care of.
 */
function update() {

}