let GameScene = new Phaser.Scene('GameScene');

const config = {

    type: Phaser.AUTO,
    roundPixels: true,
    parent: 'content',
    width: 8 * 64,
    height: 8 * 64,
    physics: {
        default: 'arcade',
        arcade: {
            debug: true
            //turned debugging on for testing
        }
    },
    scene: [
        //BootScene,
        //TitleScene,
        GameScene
    ]
};

const game = new Phaser.Game(config);
