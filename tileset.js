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
const ENEMY_SPEED = 1/500;
var enemies;
var graphics;
var path;
var TreeTurrets;
var numberTurrets;

var gridMap = [[0, -1, -1, 0, 0, 0, 0, 0, 0, 0],
               [0, -1, -1, 0, 0, 0, 0, 0, 0, 0],                                
               [0, -1, -1, 0, 0, 0, 0, 0, 0, 0],
               [0, -1, -1, -1, -1, -1, -1, -1, 0, 0],                                
               [0, -1, -1, -1, -1, -1, -1, -1, 0, 0],
               [0, 0, 0, 0, 0, 0, -1, -1, 0, 0],
               [0, 0, 0, 0, 0, 0, -1, -1, 0, 0],                                
               [0, 0, 0, 0, 0, 0, -1, -1, 0, 0],
               [0, 0, 0, 0, 0, 0, -1, -1, 0, 0],                                
               [0, 0, 0, 0, 0, 0, -1, -1, 0, 0]]

function preload() {

  this.load.image('water-tile-horizontal', 'assets/waterTile6.png');
  this.load.image('water-tile-turn-right', 'assets/waterTile32.png');
  this.load.image('water-tile-turn-down', 'assets/waterTile23.png');
  this.load.image('water-tile-vertical', 'assets/waterTile41.png');
  this.load.image('grass-tile', 'assets/terrainTile3.png');
  

  this.load.atlas('sprites', 'assets/spritesheet.png', 'assets/spritesheet.json');

  //Loads an image which can be reference by the name 'bullet'
  this.load.image('garbage', 'assets/garbagebin.png');
  this.load.image('tree', 'assets/tree.png');

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
    
    if (this.follower.t >= 1) 
    {
      // If whole path has been completed, remove the object from the scene.
      this.setActive(false);
      this.setVisible(false);
    }
  }
});

var TreeTurret = new Phaser.Class({
  Extends: Phaser.GameObjects.Image,

  initialize: 

  function TreeTurret(scene) {
    Phaser.GameObjects.Image.call(this, scene, 0, 0, 'tree');

    //nextTic is like an instance variable that defines how much time a turret will take to shoot.
    this.nextTic = 0;
    this.count = 4;
  },

  place: function(i, j) {
    console.log(i + " " + j);
    this.y = j * 32 + 16;
    this.x = i * 32 + 16;
    gridMap[i][j] = 1;
  },

  update: function(time, delta) {
    // Shoot after every second.
    if (time > this.nextTic) {
      this.nextTic = time + 1000;
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

  // Creates a static layer and displays all the sprites as described in the 'map.json' file
  const Layer0 = map.createStaticLayer("Tile Layer 1", [grassTile, waterHorizontal, waterTurnDown, waterVertical, waterTurnRight], 0, 0);

  graphics = this.add.graphics();
  path = this.add.path(64, 0);
  createPath();
  drawGrid(graphics);
  
  /* Adds the class enemies to a group from which an
   * enemy object at any time.
   */
  enemies = this.add.group({
    classType: Enemy,
    runChildUpdate: true
  });
  this.nextEnemy = 0;

  TreeTurrets = this.add.group({
    classType: TreeTurret,
    runChildUpdate: true
  });

  this.input.on('pointerdown', placeTurret);

}


function update(time, delta) {
  // Sends in enemies every two seconds
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

/**
 * Creates a transparent path for the garbage objects to follow.
 */
function createPath() {

 
  
  path.lineTo(64, 128);
  path.lineTo(224, 128);
  path.lineTo(224, 320);

  graphics.lineStyle(2, 0xff0000, 0);
  path.draw(graphics);
}

function drawGrid(graphics) {
  graphics.lineStyle(1, 0xffffff, 0);
  for (let i=0; i < 10; i++) {
    graphics.moveTo(0, i * 32);
    graphics.lineTo(320, i * 32);
  }
  for (let j = 0; j < 10; j++) {
    graphics.moveTo(j * 32, 0);
    graphics.lineTo(j * 32, 320);
  }
  graphics.strokePath();
}

/**
 * Places the turrets in a 
 * @param {*} pointer Vector representation of the point
 */
function placeTurret(pointer) {

  var i = Math.floor(pointer.x / 32);
  var j = Math.floor(pointer.y / 32);

  if (canPlaceTurret(i, j)) {
    var tree = TreeTurrets.get();
    if (tree) {
      tree.setActive(true);
      tree.setVisible(true);
      tree.place(i, j);
    }
  }

}

function canPlaceTurret(i, j) {
  console.log(gridMap[j][i] === 0);
  return gridMap[j][i] === 0;
}
    
    