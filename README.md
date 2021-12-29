# Jewel Jam - MonoGame :joystick: :video_game: :desktop_computer: 

!["screenshot1"](https://github.com/bluejynz/JewelJam-monogame/blob/main/Screenshots/gameScreenshot1.png?raw=true)

!["screenshot2"](https://github.com/bluejynz/JewelJam-monogame/blob/main/Screenshots/gameScreenshot2.png?raw=true)

!["screenshot3"](https://github.com/bluejynz/JewelJam-monogame/blob/main/Screenshots/gameScreenshot3.png?raw=true)

!["screenshot4"](https://github.com/bluejynz/JewelJam-monogame/blob/main/Screenshots/gameScreenshot4.png?raw=true)

### Made by [@bluejynz](https://www.instagram.com/bluejynz/) using [MonoGame](https://www.monogame.net)



## TODO

- [x] The game is now quite easy: players can get far by simply bashing the arrow keys and the spacebar. To make things more interesting, give the player a penalty whenever there are no valid combinations if he/she presses the spacebar. You could give the player negative points, or you could push the jewel cart forward.  *
- [x] Give the player the option to give all jewels in the grid a new random color. This is useful if the player doesn’t see any valid combinations anymore. Of course, this action should come with a price: for example, you could give negative points again, or only allow a reset if the player has earned enough points since the last reset. **
- [ ] Add a fourth color of jewels to the game: a “rainbow” color. This color serves as a “wildcard” that you can interpret as any of the three other colors. This changes how you should check for valid combinations of jewels. Make sure that the rainbow jewels are very rare: don’t add them to the grid too often.  
- [ ] Add more visual effects for when the player scores a valid combination of jewels. For example, you could let the three jewels shrink or fly out of the screen. Note: this will probably mean that a grid of jewels alone is no longer enough. Some jewels will have to “stay alive” a bit longer without being part of the grid.  
- [ ] Give each jewel a small chance to contain a power-up. When a jewel with a power-up gets removed from the grid, a special bonus effect should occur. For example, an entire row or column gets cleared, all jewels of a certain type get removed, or the jewel cart gets pushed back by an extra distance. If a jewel contains a power-up, draw a small icon in the corner of that jewel, so that the player understands what’s going on.  
- [ ] Add a hint system to the game. If the player hasn’t scored any combinations for some time, a “hint” button should appear. When the player presses this button, the game will automatically highlight three jewels in the grid that can form a valid combination. Note: these jewels may not be in the middle column yet! Finding such a combination automatically is pretty difficult. Think carefully about how you implement it.  



*Added on commit [base game ready](https://github.com/bluejynz/JewelJam-MonoGame/commit/6c035de1bc0a3a79d56f2c0009c85b5d9093697b)

**Added on commit 
