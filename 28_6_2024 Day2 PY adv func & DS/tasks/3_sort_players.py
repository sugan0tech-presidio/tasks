players = []

while True:
    name = input("Enter player's name (or 'done' to finish): ")
    if name.lower() == 'done':
        break
    score = int(input("Enter player's score: "))
    players.append((name, score))

players_sorted = sorted(players, key=lambda x: x[1], reverse=True)
top_10_players = players_sorted[:10]

print("Top 10 players:")
for player in top_10_players:
    print(f"{player[0]}: {player[1]}")

