
``` mermaid
flowchart LR
  A[General Bot] --- T1


%% Subgraphs
subgraph T1 ["<b>Flows<b>"]
 1
 B["Credit cost by country\nv2.5"]
 C["Feedback Notification\nGen Bot v2"]
 D["End Chat Feedback Teams"]
 E["Search KBA by ID v2.5"]
end

subgraph T2 ["<b>Features<b>"]
  2
  F["What is BYU Pathway Worlwide"]
  Fi["Provide an overview of BYU Pathway Worlwide"]

  G["Academic Calendar"]
  Gi["- Aplications deadlines\n- Block Academic Calendar\n- Semester Academic Calendar"]
  
  H["Certificates and Degrees"]
  Hi["Three-year Bachelor´s Degree\nAvalible Certificates\nInformation about courses"]

  I["Tuition and Financial Aid"]
  Ii["Users can view the tuition cost per credit\nfor each country, as well as the total cost\n of the degree."]

  J["Help Center"]
  Ji["- English Connect\n- Pathway Connect\n- Certificates & Degrees"]

  K["Admissions"]
  Ki["The idea is to start the admission process\n through the chatbot"]

  L["Feedback"]
  Li["Users can give a satisfaction level from 1\nto 5 and write comments about their\nexperience with the chatbot"]

  M["Integrations IA into the chatbot"]
  Mi["The Church approved the option of\nusing generative IA with the chatbot.\nThis features will be part of the new version."]

  N["Knowledge Base Articles"]
  Ni["Allows users to access the documents that\n underpin the chatbot's knowledge base."]
end

subgraph T3 ["<b>Tables<b>"]
  3
  O["Feedback"]
end
%% Connections
1 -.- 2 -.- 3
B --- I
C & D --- L
E --- N

F --- Fi
G --- Gi
H --- Hi
I --- Ii
J --- Ji
K --- Ki
L --- Li --- O
M --- Mi
N --- Ni


%% Styles
classDef titleStyle fill:#168DC7,color:#FFF,stroke-width:3px,stroke:#000000,rx:5,ry:5
classDef informationStyle fill:#00aba9,color:#FFF,stroke-width:3px,stroke:#000000,rx:5,ry:5
classDef subgraphsStyles fill:#dae8f7,stroke:#dae8f7,stroke-width:5px, height: 1150px
classDef tableStyle fill:#1478a9,color:#FFF,stroke-width:3px,stroke:#000000,rx:5,ry:5
classDef activeStyle fill:#339933,color:#FFF,stroke-width:3px,stroke:#000000,rx:5,ry:5
classDef inProgressStyle fill:#f09609,color:#FFF,stroke-width:3px,stroke:#000000,rx:5,ry:5
classDef deprecatedStyle fill:#7f7f7f,color:#FFF,stroke-width:3px,stroke:#000000,rx:5,ry:5
classDef alignStyle color:#dae8f7,stroke:#dae8f7, width:0px, height: 0px

T1:::subgraphsStyles
T2:::subgraphsStyles
T3:::subgraphsStyles

1:::alignStyle
2:::alignStyle
3:::alignStyle
linkStyle 1 stroke-width:0
linkStyle 2 stroke-width:0

A:::titleStyle

B:::tableStyle
C:::tableStyle
D:::tableStyle
E:::tableStyle

F:::activeStyle
G:::activeStyle
H:::activeStyle
I:::activeStyle
J:::inProgressStyle
K:::inProgressStyle
L:::inProgressStyle
M:::inProgressStyle
N:::activeStyle

Fi:::informationStyle
Gi:::informationStyle
Hi:::informationStyle
Ii:::informationStyle
Ji:::informationStyle
Ki:::informationStyle
Li:::informationStyle
Mi:::informationStyle
Ni:::informationStyle

O:::tableStyle
```