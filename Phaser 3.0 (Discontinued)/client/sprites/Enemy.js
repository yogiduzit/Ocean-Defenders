/*
Generic enemy class that extends Phaser sprites.
Classes for enemy types extend this class.
*/


export default class Enemy extends Phaser.GameObjects.Sprite {


    constructor(config) {
        super(config.scene, config.x, config.y, config.key);
        config.scene.physics.world.enable(this);
        config.scene.add.existing(this);

        this.alive = true;
        this.health = 100;


        this.body.allowGravity = false;
        this.beenSeen = false;

        this.body.setSize(12, 12);
        this.body.offset.set(0, 0);



        // Base horizontal velocity / direction.
        this.direction = -50;

        // Standard sprite is 16x16 pixels with a smaller body
        this.body.setSize(12, 12);
        this.body.offset.set(10, 12);
    }

    activated() {
        //move
    }

    Hit(enemy, bullet) {
        //if the enemy is hit lower the HP
    }

    hurtPlayer() {
        //check if the enemy has hit the edge of the screen
    }

    killed() {
        // Forget about this enemy
        this.scene.enemyGroup.remove(this);
        this.destroy();
    }


}
