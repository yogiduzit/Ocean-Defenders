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
var enemies;
var ENEMY_SPEED = 1/10000;
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
 * Describes the appearance and behaviour of enemies.
 */
var Enemy = new Phaser.Class({
  Extends: Phaser.GameObjects.Image,

  initialize: 

  function Enemy(scene) 
  {

    Phaser.GameObjects.Image.call(this, scene, 0, 0, 'sprites', 'enemy');
    // Loads the enemy sprite.

    this.follower = {
      t: 0,
      vec: new Phaser.Math.Vector2() 
    };
    /* 
     * 't' Checks the progress of the enemy on the path
     * At the beginning its 0, and at the end it's 1
     * 'vec' is the vector object that contains the particle's
     * coordinates.
     */

  },

  startOnPath: function() {
    this.follower.t = 0;
    // Setting 't' to '0' initially.

    path.getPoint(this.follower.t, this.follower.vec);
    // Getting the value of 't' and its position vector.

    this.setPosition(this.follower.vec.x, this.follower.vec.y);
    // Sets the initial position of the enemies as recieved.
  },


  update: function(time, delta) {
    this.follower.t += ENEMY_SPEED * delta;
    // Move the t point along the path.

    path.getPoint(this.follower.t, this.follower.vet);

    this.setPosition(this.follower.vec.x, this.follower.vec.y);
    // If whole path has been completed, remove the object from the scene.
    if (this.follower.t >= 1) 
    {
      
      this.setActive(false);
      this.setVisible(false);
    }
  }
});


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

  enemies = this.add.group({
    classType: Enemy,
    runChildUpdate: true
  });
  this.nextEnemy = 0;
}


/**
 * Updates the game every frame to make sure that all the events are taken care of.
 */
function update(time, delta) {
  if (time > this.nextEnemy) {
    var enemy = enemies.get();
    if (enemy) {
      enemy.setActive(true);
      enemy.setVisible(true);
      enemy.startOnPath();
      
      this.nextEnemy = time + 2000;
    }
  }
}


