#ifndef TILE_MAP_H 
#define TILE_MAP_H

#include <vector>
#include <list>
#include <iostream> // debug 
#include <fstream>
#include <random>
#include <irrKlang.h>
#pragma comment(lib, "irrKlang.lib")



#include "Direction.h"

#include "Cell.h"



class TileMap {

public:

	TileMap() = default;

	TileMap(float winWidth, float winHeight);

	void init(std::string const& fileName);
	void movePlayerTiles(Direction const& dir);
	void escape(int enemyType);
	bool isRestarting() const;
	void reset();
	void render();
	void free();
	void setBackgroundMusic(bool value);


private:
	
	

	// typedefs to simplify expressions
	typedef std::vector<Cell> CellVector;
	typedef std::vector<Cell*> CellRefVector;
	typedef std::vector<CellVector> CellMatrix;

	void applyInteraction(Type const& nameType, Type const& operatorType, Type const& actionType)const;
	bool insideMap(std::pair<int, int> const& pos)const;

	void moveTile(std::pair<int, int> const& initialPos, Direction const& dir);
	Type getBottomType(std::pair<int, int> const& pos)const;
	void findInteractions(std::pair<int, int> const& namePos, Direction const& dir);
	void initSound();
	void updateInteractions();
	bool renderRow(int row);
	void renderTiles();
	bool moveMarked(std::pair<int, int> const& pos, Direction const& dir);
	void loadMap();
	bool unloadMap();

	void tryMove(int i, int j, Direction const& dir);

	void upPath(Direction const& dir);
	void downPath(Direction const& dir);
	void leftPath(Direction const& dir);
	void rightPath(Direction const& dir);


	static const int LOAD_SPEED = 8;
	std::vector<std::string> BABA_MOVE_SOUND = { "sound/043.ogg", "sound/044.ogg", "sound/045.ogg", "sound/046.ogg" };
	std::string  WIN_SOUND = "sound/042.ogg";
	std::string  RESET_SOUND = "sound/085.ogg";
	std::string  LOAD_SOUND = "sound/026.ogg"; // 26
	std::string  THEME_SOUND = "sound/theme_soundtrack.mp3";

	int mapWidth;
	int windowHeight;
	int windowWidth;
	int mapHeight;

	bool loaded;
	bool unloaded;
	bool playThemeSound;
	static bool restarted;
	bool firstLoad;
	
	std::vector<std::pair<int, int>> cols;
	static irrklang::ISoundEngine* engine;
	static  irrklang::ISound* backgroundMusic;

	CellMatrix map;
	CellRefVector names;
};


#endif 