using System;
using System.Collections.Generic;
using TP1_IA.model;

namespace TP1_IA.strategy
{
    public class UninformedSearch : SearchStrategy
    {
        private Node search(Node node, int depth)
        {
            if (!Desire.desireReach(node) && depth != 0)
            {
                foreach (Node nextNode in node.nextNode())
                {
                    search(nextNode, depth - 1);
                }
            }

            return node;
        }

        public void execute(Node node, int depth)
        {
            search(node, depth);
        }


        // recherche en pronfondeur jusqu'� une limite : regarde toutes les actions en partant d'un noeuds jusqu'� la profondeur, puis un autre noeuds etc.
        public Node depthLimitedSearch(Agent agent, int profondeurMax)
        {
            Node root = new Node(agent.Coordonnees, agent.Belief.Jewels, agent.Belief.Dust, 0);
            Node currentNode = root;
            int profondeurActuelle = 0;
            int indexAction = 0;
            int actionSize = 4; // Quantit� d'action dans l'�num
            Boolean keeprunning = true;

            // tant que l'arbre n'est pas plein
            while (profondeurActuelle != profondeurMax && indexAction != actionSize && !root.getChild(actionSize - 1).Equals(null) && keeprunning) 
            {
                // Si on est pas au fond
                if(indexAction < actionSize && profondeurActuelle != profondeurMax)
                {
                    // on fait l'action choisi et on change le noeud courant
                    currentNode.addChild(doStuff(currentNode, indexAction));
                    // Si on a fait toutes les actions pour ce noeud
                    if(indexAction == actionSize)
                    {
                        // si on peut aller en profondeur 
                        if(profondeurActuelle < profondeurMax)
                        {
                            if (root.getChild(indexAction) != null)
                            {
                                profondeurActuelle++;
                                currentNode = root.getChild(indexAction);
                            }
                            else
                            {
                                if (indexAction < actionSize)
                                {
                                    indexAction++;
                                }
                                else
                                {
                                    profondeurActuelle--;
                                    indexAction = 0;
                                }
                            }
                        }
                        // si on est d�j� au fond et qu'on a fait toutes les Actions
                        else
                        {
                            
                            if (root.getFather() != null)
                            {
                                profondeurActuelle--;
                                currentNode = currentNode.getFather();
                            }
                            else // fini ou bug
                            {
                                keeprunning = false;
                            }
                        }
                        indexAction = 0;
                    }
                    // Si il rests des actions � effectuer sur le noeud
                    else
                    {
                        // si on n'est pas au fond
                        if (profondeurActuelle < profondeurMax)
                        {
                            if (root.getChild(indexAction) != null)
                            {
                                profondeurActuelle++;
                                currentNode = root.getChild(indexAction);
                            }
                            else
                            {
                                if(indexAction < actionSize)
                                {
                                    indexAction++;
                                }
                                else
                                {
                                    profondeurActuelle--;
                                    indexAction = 0;
                                }
                            }
                        }
                        // Si on est au fond
                        else
                        {
                            indexAction++;
                        }
                    }
                   
                }
                else // c'est qu'on est d�ja pass� par ce cot�, il faut avanc� dans l'arbre
                {
                    if (indexAction == actionSize - 1)
                    {
                        if (root.getFather() != null)
                        {
                            profondeurActuelle--;
                            currentNode = currentNode.getFather();
                        }
                        else // fini ou bug
                        {
                            keeprunning = false;
                        }
                    }
                    else
                    {
                        indexAction++;

                    }
                }
            }
            return root;

        }

        public Node doStuff(Node node, int indexAction)
        {
            if (indexAction == 0) // haut
            {
                if (node.Coordonnees.X == 0)
                    return null;
                else
                    return new Node(new Coordonnees((node.Coordonnees.X - 1), node.Coordonnees.Y), node.Jewels, node.Dust, node.getScore()-1);
            }
            if (indexAction == 1) // bas
            {
                if (node.Coordonnees.X == 10)
                    return null;
                else
                    return new Node(new Coordonnees((node.Coordonnees.X + 1), node.Coordonnees.Y), node.Jewels, node.Dust, node.getScore() - 1);
            }
            if (indexAction == 2) // droite
            {
                if (node.Coordonnees.Y == 10)
                    return null;
                else
                    return new Node(new Coordonnees((node.Coordonnees.X), node.Coordonnees.Y+1), node.Jewels, node.Dust, node.getScore() - 1);
            }
            if (indexAction == 3) // gauche
            {
                if (node.Coordonnees.Y == 0)
                    return null;
                else
                    return new Node(new Coordonnees((node.Coordonnees.X), node.Coordonnees.Y - 1), node.Jewels, node.Dust, node.getScore() - 1);
            }
            if (indexAction == 4) // aspirer
            {
                if (Environnement.Instance.getRoom(node.Coordonnees).Equals(EnumIA.Chambre.bijou) || Environnement.Instance.getRoom(node.Coordonnees).Equals(EnumIA.Chambre.poussiereEtBijou))
                    return new Node(new Coordonnees((node.Coordonnees.X), node.Coordonnees.Y), node.Jewels, node.Dust, node.getScore() - 15);
                else
                    if(Environnement.Instance.getRoom(node.Coordonnees).Equals(EnumIA.Chambre.poussiere))
                        return new Node(new Coordonnees((node.Coordonnees.X), node.Coordonnees.Y), node.Jewels, node.Dust, node.getScore() +10);
                return new Node(new Coordonnees((node.Coordonnees.X), node.Coordonnees.Y), node.Jewels, node.Dust, node.getScore() - 1);

            }
            if (indexAction == 5) // recuperer
            {
                if (Environnement.Instance.getRoom(node.Coordonnees).Equals(EnumIA.Chambre.bijou) || Environnement.Instance.getRoom(node.Coordonnees).Equals(EnumIA.Chambre.poussiereEtBijou))
                    return new Node(new Coordonnees((node.Coordonnees.X), node.Coordonnees.Y), node.Jewels, node.Dust, node.getScore() + 20);
                return new Node(new Coordonnees((node.Coordonnees.X), node.Coordonnees.Y ), node.Jewels, node.Dust, node.getScore() - 1);
            }
        }





            /* Cr�ation d'un arbre
             * Cr�ation profondeur = 0
             * Cr�ation indexAction = 0
             * while( arbre[profondeurMax].[actionSize] != null)
             * {
             *     if(indexAction < actionSize && si arbre[profondeurActuelle].[indexAction] == null){
             *          ajout dans arbre[profondeurActuelle].[indexAction].environementMAJavecAction
             *          
             *          if(indexAction == actionSize-1){
             *             if(profondeurActuelle < profondeurMax)
            *                   profondeurActuelle++;
            *              else
            *                   profondeur--;
            *              indexAction = 0;
            *          } else{
            *              if(profondeurActuelle < profondeurMax)
            *                   profondeurActuelle++;
            *              else{
            *                   indexAction++;
            *              }
            *          }
        *          }
             *     else // c'est qu'on est d�ja pass� par ce cot�, il faut avanc� dans l'arbre
             *     {
             *          if(indexAction == actionSize-1)
             *              profondeur--;
             *          else
             *              indexAction++;
             *     }
        *          
             * }
             */
        }

        /*  public void recursive(int profondeurActuelle, int profondeurMax, int indexAction)
          {
              if(profondeurActuelle == profondeurMax && indexAction == System.Enum.GetNames(typeof(model.Enum.Action)).Length)
              {
                  profondeurActuelle--;
                  indexAction = 0;
                  recursive(profondeurActuelle, profondeurMax, indexAction);
              }
              else
              {
                  if()
              }
          }*/
    }

/*
 * X = profondeur, Y = Enum.action()
 * jusqu'� profondeur X : 
 * 1 faire l'action Y
 * 2 Si t'es � X, tu remontes ou si Y est au max
 * 3 Si tu peux faire une action Y+1, alors tu la fait
 * 
 */