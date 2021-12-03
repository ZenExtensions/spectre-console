# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

## [1.3.1] - 2021-12-03

### Changed

- Updated dependencies

## [1.3.0] - 2021-10-07

### Changed

- BaseStartup is now part of namespace `Zen.Host`

## [1.2.0] - 2021-10-02

### Added

- Added args passing to the startup class
- Added separate ICommandConfigurator interface to work with configuring commandapp

### Removed

- Removed ConfigureCommandApp from BaseStartup

## [1.1.0] - 2021-06-28

### Updated

- Updated dependencies

## [1.0.0] - 2021-06-12

### Added

- Added SpectreConsoleHost class for working with SpectreConsole
- Added Startup class for configuring DI
- Added extension functions for spectre console
- Added type registrar and type resolver for DI
- Added ConfigureCommandApp function for configuring commands 

[Unreleased]: https://github.com/WajahatAliAbid/zen-spectreconsole-extensions/compare/1.3.1...HEAD
[1.3.1]: https://github.com/WajahatAliAbid/zen-spectreconsole-extensions/compare/1.3.0...1.3.1
[1.3.0]: https://github.com/WajahatAliAbid/zen-spectreconsole-extensions/compare/1.2.0...1.3.0
[1.2.0]: https://github.com/WajahatAliAbid/zen-spectreconsole-extensions/compare/1.1.0...1.2.0
[1.1.0]: https://github.com/WajahatAliAbid/zen-spectreconsole-extensions/compare/1.0.0...1.1.0
[1.0.0]: https://github.com/WajahatAliAbid/zen-spectreconsole-extensions/releases/tag/1.0.0