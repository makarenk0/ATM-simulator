#pragma once
#include <map>
#include <string>
#include <fstream>
#include <vector>

class CardsInfoWorker
{
public:
	CardsInfoWorker();
	CardsInfoWorker(const std::string& cardsFilepath, const std::string& blockedFilepath);

    std::map<std::string, std::pair<std::string, int>> _cardData;
	std::vector<std::string> _blockedCards;

	bool isCardBlocked(const std::string& card);
	void blockCard(const std::string& card);
	void unblockCard(const std::string& card);
	bool withdrawCash(const std::string& card, int amount);

	void unblockAll();

	void saveCardsInfoFile();
private:
	void parseDataCardsFile(const std::string& path);
	void parseBlockedCardsFile(const std::string& path);
	void saveBlockedCardsFile();

	std::vector<std::string> split(std::string s, std::string delimiter);

	std::string _cardsFilepath;
	std::string _blockedFilepath;
};

