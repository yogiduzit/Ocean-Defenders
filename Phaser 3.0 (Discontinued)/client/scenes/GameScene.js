GameScene.preload = function () {

    // load the game assets – enemy and turret atlas
    this.load.tilemapTiledJSON('map', '../assets/tilemaps/map.json');
    this.load.image('tiles', '../assets/tilemaps/tilesheet.png');


    // This group contains all enemies for collision and calling update-methods
    this.enemyGroup = this.add.group();

    // Populate enemyGroup, powerUps, pipes and destinations from object layers
    this.parseObjectLayers();

};

GameScene.create = function () {


    this.map = this.make.tilemap({
        key: 'map'
    });

    this.tileset = this.map.addTilesetImage('tilesheet', 'tiles');
    this.layer = this.map.createStaticLayer('Tile Layer 1', this.tileset, 0, 0);



    this.marker = this.add.graphics();
    this.marker.lineStyle(3, 0xffffff, 1);
    this.marker.strokeRect(0, 0, this.map.tileWidth, this.map.tileHeight);


    // This group contains all enemies for collision and calling update-methods
    this.enemyGroup = this.add.group();


};

GameScene.update = function (time, delta) {

    var worldPoint = this.input.activePointer.positionToCamera(this.cameras.main);

    // Rounds down to nearest tile
    var pointerTileX = this.map.worldToTileX(worldPoint.x);
    var pointerTileY = this.map.worldToTileY(worldPoint.y);

    // Snap to tile coordinates, but in world space
    this.marker.x = this.map.tileToWorldX(pointerTileX);
    this.marker.y = this.map.tileToWorldY(pointerTileY);




};

GameScene.parseObjectLayers = function () {

    //implementation needed to load enemies.
};
