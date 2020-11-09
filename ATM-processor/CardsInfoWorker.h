#pragma once
#include <map>
#include <string>
#include <fstream>
#include <vector>

class CardsInfoWorker
{
public:
	CardsInfoWorker();
	CardsInfoWorker(const std::string& path);
    std::map<std::string, std::pair<std::string, int>> _cardData;
private:
	void parseDataCardsFile(const std::string& path);
	std::vector<std::string> split(std::string s, std::string delimiter);
};

