#pragma once

#include <unordered_map>

namespace learning
{
    // ENUMERATION CLASS CONSTRAINTS FOR DATABASE OBJECTS
    enum class CharacterSize
    {
        kSmall,
        kMedium,
        kLarge
    };


    // INIT DATAMAP
    std::unordered_map<CharacterSize, const char *> character_size_to_string({
        {CharacterSize::kSmall, "small"},
        {CharacterSize::kMedium, "medium"},
        {CharacterSize::kLarge, "large"},
    });

}