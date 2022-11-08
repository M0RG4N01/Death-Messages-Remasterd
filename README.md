# Death Messages Remastered

This plugin allows death messages to be shown in chat when a player dies.
Also allows giving players Uconomy cash or Exp for killing someone.

[Download from the github releases](https://github.com/Pustalorc/Death-Messages-Remasterd/releases/latest)

# Features

- Custom color for all death messages (not respectively).
- Rich text support for all death messages.
- All death messages are fully configurable based on the cause of death.
- Display weapon name used by the Killer (if killed with one).
- Display remaining health of the Killer.
- Display distance of the kill (distance between Killer and Victim).
- Display warnings when someone reaches low health (private warnings).
- Custom messages for head kills (headshot, melee to the head, punch to the head).
- EXP or Uconomy cash given to murderers depending on which body part they hit to kill a player.
- Enable/disable specific parts of the plugin such as Uconomy rewards, Zombie death messages, Exp rewards, Low Health
  Warning messages and Suicide messages.

# Translations

#### Kill Translations

{0} - Victim's name (Defaults to `Someone` if not available)

{1} - Killer's name (Defaults to `Anonymous` if not available)

{2} - Killer's health (Defaults to `0` if not available)

{3} - Killer's vehicle name (Defaults to `N/A` if not available)

{4} - Killer's weapon name (Defaults to `N/A` if not available)

{5} - Distance between killer and victim (Each position defaults to `0` if not available)

Example Translation:

`{0} was shot by {1} from {5}m using a {4}. Remaining health: {2}%`

Example Output:

`Pustalorc was shot by Morgan from 50m using a Timberwolf. Remaining health: 85%`

#### Reward Translations

{0} - Money Symbol (Will be empty if it's an experience reward)

{1} - Money Reward

{2} - Money Name (Will be `EXP` if it's an experience reward)

Example Translation:
`You received {0}{1} {2} for getting a head punch kill!`

Example Output:
`You received $50 dosh for getting a head punch kill!`

# What if I don't want to use uconomy?

Make sure then that you have uconomy in the library folder located in `\Servers\server\Rocket\Libraries`

# What if I use AviEconomy?

Then you should use UconomyToAviEconomy, provided by Avi's gateway plugin.