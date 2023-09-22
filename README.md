# BallSplash-MobileComputing
Repository per il SRC code del progetto di Mobile Computing
-----------------------------------------------------------
"Ball Splash" si basa sul concept della pluripremiata serie di 
giochi arcade "Fruit Ninja": stavolta non c'è frutta da tagliare,
bensì svariati oggetti da "scoppiare", occhio però a quali scegliere...
Volendo riassumere le principali funzionalità e caratteristiche del gioco:
1. La partita dura complessivamente 30 secondi, alla fine di questa sarà
   presente un button "New Game" per iniziare una nuova partita ed il punteggio
   rimane stampato a video nella posizione in cui è durante lo svolgimento della stessa
2. Tutti gli oggetti, apparte teschi e bombe, assegnano un punteggio incrementale
   seguendo la logica di "streak": ogni 10 oggetti di fila "scoppiati" si ottiene un incremento
   di +1 rispetto al punteggio assegnato precedentemente da ciascun oggetto. Per intenderci, inizialmente
   viene assegnato un +1 ad ogni "esplosione", dopo 10 di queste ne verranno assegnati +2, dopo 20 ne verranno
   assegnati +3... Le streak si interrompono non solo quando viene "esploso" un teschio od una bomba, ma anche
   quando non si "esplodono" tutti gli altri oggetti correntemente a schermo: se non li "esplodiamo" tutti e ne
   manchiamo qualcuno, allora terminerà anche la streak
3. "Esplodere" teschi e bombe causa effetti differenti: nonostante entrambi, se "esplosi", causino la terminazione della streak corrente,
    "esplodere" una bomba comporta una perdita di -5 punti, mentre il teschio causa la terminazione della partita corrente 
4. Il gioco conta di livelli di difficoltà regolabili con una apposito "regolatore a barra" posto direttamente precedente all'inizio della
   partita. Cosa cambierà tra questi livelli di difficoltà? Ho scelto di incrementare la percentuale di spawn di "oggetti pericolosi" proporzionalmente
   alla difficoltà della partita, ovvero: più la difficoltà è impostata a livello alto, più bombe e teschi ci troveremo a dover gestire durante la partita
5. Tutti gli oggetti nel gioco sono modellati secondo una "fisica di contatto": urtando tra di loro creano traiettorie imprevedibili, rendendo l'accumulazione
   di punti molto difficile quando ci sono in ballo molti teschi e bombe

Creato da: Domenico De Marchis - 578132.
P.S: Professore, Le avevo scritto una mail riguardo, nell'eventualità di una valutazione positiva del progetto, possibili problematiche in termini di valutazione e verbalizzazione di quest'ultima, essendo io appena iscritto al Terzo Anno. Mi contatterà Lei nell'eventualità.
