# Change Log

All notable changes to this project will be documented in this file. See [versionize](https://github.com/versionize/versionize) for commit guidelines.

<a name="1.1.1"></a>
## [1.1.1](https://www.github.com/thiagomvas/SteamWebSharp/releases/tag/v1.1.1) (2025-09-10)

### Bug Fixes

* GetGlobalAchievementPercentages correctly parses the response ([efe5c17](https://www.github.com/thiagomvas/SteamWebSharp/commit/efe5c17126806424287b193765dc464c075f1a43))

<a name="1.1.0"></a>
## [1.1.0](https://www.github.com/thiagomvas/SteamWebSharp/releases/tag/v1.1.0) (2025-09-10)

### Features

* Add base IPlayerService interface with GetOwnedGames endpoint ([b7db8a2](https://www.github.com/thiagomvas/SteamWebSharp/commit/b7db8a207ccfa4eef5ce5c185125a9b52f16942e))
* Add IPlayerService/GetLastPlayedTimes and IPlayerService/GetRecentlyPlayed ([4814b43](https://www.github.com/thiagomvas/SteamWebSharp/commit/4814b432ac3cabca15b00ceaff1eca5168378bc8))

### Bug Fixes

* Add missing ISteamMarket setter for builder ([207a31e](https://www.github.com/thiagomvas/SteamWebSharp/commit/207a31ed21b7eae0605800f8971fdae7c4e5a2cd))

<a name="1.0.0"></a>
## [1.0.0](https://www.github.com/thiagomvas/SteamWebSharp/releases/tag/v1.0.0) (2025-01-12)

### Features

* Add Batch calls for GetPlayerSummaries and GetPlayerBans ([006f062](https://www.github.com/thiagomvas/SteamWebSharp/commit/006f0628b969e6a39fb1efc5c1a1bf51b0a0c0f4))
* Add Caching support ([36b8087](https://www.github.com/thiagomvas/SteamWebSharp/commit/36b8087f7e342730d95921d544c50149dc2f99f4))
* Add configurable Language support ([dc524f2](https://www.github.com/thiagomvas/SteamWebSharp/commit/dc524f29e66616b544c0d7c43074f47d074decce))
* Add GetPlayerAchievements and GetUserStatsForGame ([820fb8c](https://www.github.com/thiagomvas/SteamWebSharp/commit/820fb8c001486da2c0552f4968bb9d79be2f6f18))
* Add GetSchemaForGame ([49de4cb](https://www.github.com/thiagomvas/SteamWebSharp/commit/49de4cb3e3da24c1a6205ff388901fe8efa5f4eb))
* Add ISteamNews endpoints ([b8b5fed](https://www.github.com/thiagomvas/SteamWebSharp/commit/b8b5fed41bae0787ce1efc89da385ba774fb7f28))
* Add ISteamUserStats/GetGlobalAchievementPercentagesForApp ([006eb86](https://www.github.com/thiagomvas/SteamWebSharp/commit/006eb8695c99a541daa46c4ac2e7d40127d84ab6))
* Add ITeamFortress interface to client ([579c2c1](https://www.github.com/thiagomvas/SteamWebSharp/commit/579c2c12df7fb132c6021a16b6cce7740107e067))
* Add Steam Market Endpoints ([ddd2697](https://www.github.com/thiagomvas/SteamWebSharp/commit/ddd2697bfc26a9975124ebc9ffff560f810526a6))
* Add SteamAPiClientBuilder and ILogger support ([a0b696f](https://www.github.com/thiagomvas/SteamWebSharp/commit/a0b696fea5d7dd4e3cc2d6a44704018235256204))
* Add Team Fortress endpoint ([5fb8965](https://www.github.com/thiagomvas/SteamWebSharp/commit/5fb8965fe1934d1a02fb915d7a487f008ebfab3b))
* Migrate options to Configuration class and add retry support ([8f51825](https://www.github.com/thiagomvas/SteamWebSharp/commit/8f51825a79c56ca9e8df8c0b35ec9dadaaa2b572))

### Bug Fixes

* Fix namespaces ([c93dacb](https://www.github.com/thiagomvas/SteamWebSharp/commit/c93dacbb1aa59298185bcc14fa0c16631a63fd0b))

