#pragma once
#include <map>
#include <string>
#include <fstream>
#include <vector>

class CardsInfoWorker
{
public:
	CardsInfoWorker();
	CardsInfoWorker(const std::string& cardsFilepath, const std::string& blockedFilepath, const std::string& atmCashFilepath);

    std::map<std::string, std::pair<std::string, int>> _cardData;
	std::vector<std::string> _blockedCards;
	int _atmCash;

	bool isCardBlocked(const std::string& card);
	void blockCard(const std::string& card);
	void unblockCard(const std::string& card);
	bool withdrawSum(const std::string& card, int amount);  //virtual money operations
	bool withdrawCash(const std::string& card, int amount);

	void unblockAll();
	bool rechargeCardBalance(const std::string& card, int amount);
	void rechargeATMCash(int amount);
	void saveCardsInfoFile();

	int getCardBalance(const std::string& card);

	bool cardExists(const std::string& card);
private:
	void parseDataCardsFile(const std::string& path);
	void parseBlockedCardsFile(const std::string& path);
	void parseATMCashAmount(const std::string& path);

	void saveBlockedCardsFile();
	void saveATMCashFile();

	std::vector<std::string> split(std::string s, std::string delimiter);

	std::string _cardsFilepath;
	std::string _blockedFilepath;
	std::string _atmCashFilepath;
};

