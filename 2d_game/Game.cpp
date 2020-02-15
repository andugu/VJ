#include <GL/glew.h>
#include <GL/glut.h>
#include "Game.h"

 Game& Game::instance()
{
	static Game G;

	return G;
}

void Game::init()
{
	bPlay = true;
	glClearColor(0.3f, 0.3f, 0.3f, 1.0f);
	scene.init();
}

bool Game::update(int deltaTime){

	
	scene.update(deltaTime);
	
	return bPlay;
}

void Game::render()
{
	glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
	scene.render();
}

void Game::keyPressed(int key)
{
	if (key == 27) // Escape code
		bPlay = false;

	keys[key] = true;
}

void Game::keyReleased(int key)
{
	keys[key] = false;
}

void Game::specialKeyPressed(int key){
	
	
	specialKeys[key] = true;
}

void Game::specialKeyReleased(int key){
	if (key == GLUT_KEY_RIGHT)
		scene.move(1.0, 0);
	else if (key == GLUT_KEY_LEFT)
		scene.move(-1.0, 0);
	else if (key == GLUT_KEY_UP)
		scene.move(0.0, -1.0);
	else if (key == GLUT_KEY_DOWN)
		scene.move(0.0, 1.0);
	specialKeys[key] = false;
}

void Game::mouseMove(int x, int y)
{
}

void Game::mousePress(int button){

}

void Game::mouseRelease(int button)
{
}

bool Game::getKey(int key) const
{
	return keys[key];
}

bool Game::getSpecialKey(int key) const
{
	
	return specialKeys[key];
}





