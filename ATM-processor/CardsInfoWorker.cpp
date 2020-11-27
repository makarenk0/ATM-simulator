#include "pch.h"
#include "CardsInfoWorker.h"

CardsInfoWorker::CardsInfoWorker()
{
}

CardsInfoWorker::CardsInfoWorker(const std::string& cardsFilepath, const std::string& blockedFilepath, const std::string& atmCashFilepath) : _cardsFilepath(cardsFilepath), _blockedFilepath(blockedFilepath), _atmCashFilepath(atmCashFilepath)
{
	parseDataCardsFile(cardsFilepath);
    parseBlockedCardsFile(blockedFilepath);
    parseATMCashAmount(atmCashFilepath);
}

bool CardsInfoWorker::isCardBlocked(const std::string& card)
{
    return std::find(_blockedCards.begin(), _blockedCards.end(), card) != _blockedCards.end();
}

void CardsInfoWorker::blockCard(const std::string& card)
{
    if (!isCardBlocked(card)){
        _blockedCards.push_back(card);
        saveBlockedCardsFile();
    } 
}

void CardsInfoWorker::unblockCard(const std::string& card)
{
    std::remove(_blockedCards.begin(), _blockedCards.end(), card);
    saveBlockedCardsFile();
}

bool CardsInfoWorker::withdrawSum(const std::string& card, int amount)
{
    if (_cardData[card].second >= amount) {
        _cardData[card].second -= amount;
        saveCardsInfoFile();
        return true;
    }
    return false;
}

bool CardsInfoWorker::withdrawCash(const std::string& card, int amount)
{
    if (_atmCash >= amount) {
        _atmCash -= amount;
        saveATMCashFile();
        return withdrawSum(card, amount);
    }
    return false;
}

void CardsInfoWorker::unblockAll()
{
    if (!_blockedCards.empty()) {
        _blockedCards.clear();
        saveBlockedCardsFile();
    }
}

bool CardsInfoWorker::rechargeCardBalance(const std::string& card, int amount)
{
    if (cardExists(card)) {
        _cardData[card].second += amount;
        saveCardsInfoFile();
        return true;
    }
    return false;
}

void CardsInfoWorker::rechargeATMCash(int amount)
{
    _atmCash += amount;
    saveATMCashFile();
}

void CardsInfoWorker::saveCardsInfoFile()
{
    std::ofstream cardsFile;
    cardsFile.open(_cardsFilepath);
    for (auto const& x : _cardData)
    {
        cardsFile << x.first << " " << x.second.first << " " << x.second.second << "\n";
    }
    cardsFile.close();
}

int CardsInfoWorker::getCardBalance(const std::string& card)
{
    return _cardData[card].second;
}

bool CardsInfoWorker::cardExists(const std::string& card)
{
    if (_cardData.find(card) != _cardData.end()) {
        return true;
    }
    return false;
}

void CardsInfoWorker::changeCardPin(const std::string& card, const std::string& newPin)
{
    _cardData[card].first = newPin;
    saveCardsInfoFile();
}

void CardsInfoWorker::parseDataCardsFile(const std::string& path)
{
	std::ifstream inFile;
	inFile.open(path);

	std::string line;
	while (std::getline(inFile, line))
	{
        std::vector<std::string> tokens = split(line, " ");
        _cardData.insert({ tokens[0], std::pair<std::string, int>({tokens[1], std::stoi(tokens[2])}) });
	}

    inFile.close();

}

void CardsInfoWorker::parseBlockedCardsFile(const std::string& path)
{
    std::ifstream inFile;
    inFile.open(path);

    std::string line;
    while (std::getline(inFile, line))
    {
        _blockedCards.push_back(line);
    }

    inFile.close();

}

void CardsInfoWorker::parseATMCashAmount(const std::string& path)
{
    std::ifstream inFile;
    inFile.open(path);

    std::string line;
    std::getline(inFile, line);
    _atmCash = std::stoi(line);
    inFile.close();
}

void CardsInfoWorker::saveBlockedCardsFile()
{
    std::ofstream blockFile;
    blockFile.open(_blockedFilepath);
    for (int i = 0; i < _blockedCards.size(); i++) {
        blockFile << _blockedCards[i] << "\n";
    }
    blockFile.close();
}

void CardsInfoWorker::saveATMCashFile()
{
    std::ofstream cashFile;
    cashFile.open(_atmCashFilepath);
    
    cashFile << _atmCash << "\n";
    
    cashFile.close();
}

std::vector<std::string> CardsInfoWorker::split(std::string s, std::string delimiter) {
    size_t pos_start = 0, pos_end, delim_len = delimiter.length();
    std::string token;
    std::vector<std::string> res;

    while ((pos_end = s.find(delimiter, pos_start)) != std::string::npos) {
        token = s.substr(pos_start, pos_end - pos_start);
        pos_start = pos_end + delim_len;
        res.push_back(token);
    }

    res.push_back(s.substr(pos_start));
    return res;
}

