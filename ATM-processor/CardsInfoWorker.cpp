#include "pch.h"
#include "CardsInfoWorker.h"

CardsInfoWorker::CardsInfoWorker()
{
}

CardsInfoWorker::CardsInfoWorker(const std::string& path)
{
	parseDataCardsFile(path);
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

