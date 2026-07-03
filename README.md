# House-Fighting Game 🎮

Een eerste-persoons shooter game gebouwd in Unity waar je als mens in een huis moet overleven en alle bots moet verslaan!

## Gameplay
- **Doel:** Verslaan alle bots voordat zij jou verslaan
- **Controls:**
  - WASD: Beweging
  - Muis: Camera kijken
  - Links klikken: Schieten
- **Items:** Verzamel munitie en gezondheid items in het huis

## Project Structuur
```
Assets/
├── Scripts/
│   ├── Player.cs          - Spelaasbesturing en shooting
│   ├── Bot.cs             - Bot AI en aanval logica
│   ├── Bullet.cs          - Projectiel collision
│   ├── ItemSpawner.cs     - Item spawn systeem
│   ├── ItemPickup.cs      - Item pickup logica
│   ├── GameManager.cs     - Spel staat beheer
│   └── UI.cs              - UI weergave
└── Prefabs/
    ├── Player
    ├── Bot
    ├── Bullet
    ├── HealthPickup
    └── AmmoPickup
```

## Features
✅ Player movement en camera controle
✅ Shooting systeem met munitie
✅ Bot AI met detectie en aanval
✅ Health en ammo pickups
✅ Game over condities
✅ UI systeem voor info weergave

## Setup Instructies
1. Clone deze repository
2. Open in Unity (2022 LTS of later)
3. Maak de Level scene aan
4. Plaats de prefabs in de scene
5. Play!

## Toekomstige Features
- [ ] Verschillende wapen types
- [ ] Meer bot varianten
- [ ] Betere grafische effecten
- [ ] Geluid effects
- [ ] Level design verbetering

Veel plezier met spelen! 🎯
