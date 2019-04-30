var config = {
  type: Phaser.AUTO,
  parent: 'content',
  width: 320,
  height: 320,
  physics: {
      default: 'arcade'
  },
  scene: {
    key: 'main',
      preload: preload,
      create: create,
      update: update
  }
};
var game = new Phaser.Game(config);
const ENEMY_SPEED = 1/5000;
var enemies;
var graphics;
var path;

function preload() {

  this.load.image('water-tile-horizontal', 'assets/waterTile6.png');
  this.load.image('water-tile-turn-right', 'assets/waterTile32.png');
  this.load.image('water-tile-turn-down', 'assets/waterTile23.png');
  this.load.image('water-tile-vertical', 'assets/waterTile41.png');
  this.load.image('grass-tile', 'assets/terrainTile3.png');

  this.load.atlas('sprites', 'assets/spritesheet.png', 'assets/spritesheet.json');

  //Loads an image which can be reference by the name 'bullet'
  this.load.image('garbage', 'assets/garbagebin.png');

  this.load.tilemapTiledJSON("map", "assets/map.json");

}
/**
 * Describes the appearance and behaviour of enemies.
 */
var Enemy = new Phaser.Class({
  Extends: Phaser.GameObjects.Image,

  initialize: 

  function Enemy(scene) 
  {

    Phaser.GameObjects.Image.call(this, scene, 0, 0, 'garbage');
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
    path.getPoint(this.follower.t, this.follower.vec);

    this.setPosition(this.follower.vec.x, this.follower.vec.y);
    // If whole path has been completed, remove the object from the scene.
    if (this.follower.t >= 1) 
    {
      
      this.setActive(false);
      this.setVisible(false);
    }
  }
});

function create() {
  

  const map = this.make.tilemap({key: "map"});
  const grassTile = map.addTilesetImage('terrainTile3', 'grass-tile');
  const waterTurnDown = map.addTilesetImage("waterTile23", "water-tile-turn-down");
  const waterHorizontal = map.addTilesetImage("waterTile6", "water-tile-horizontal");
  const waterVertical = map.addTilesetImage("waterTile41", "water-tile-vertical");
  const waterTurnRight = map.addTilesetImage("waterTile32", "water-tile-turn-right"); 

  const Layer0 = map.createStaticLayer("Tile Layer 1", [grassTile, waterHorizontal, waterTurnDown, waterVertical, waterTurnRight], 0, 0);

  graphics = this.add.graphics();
  path = this.add.path(64, 0);
  path.lineTo(64, 128);
  path.lineTo(224, 128);
  path.lineTo(224, 320);

  graphics.lineStyle(2, 0xff0000, 0);
  path.draw(graphics);

  enemies = this.add.group({
    classType: Enemy,
    runChildUpdate: true
  });
  this.nextEnemy = 0;

}

function update(time, delta) {
  if (time > this.nextEnemy)
    {
        var enemy = enemies.get();
        if (enemy)
        {
            enemy.setActive(true);
            enemy.setVisible(true);
            enemy.startOnPath();

            this.nextEnemy = time + 2000;
        }       
    }
}


    
    