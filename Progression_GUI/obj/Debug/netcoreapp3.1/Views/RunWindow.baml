   M S B A M L   `   `   `  ����J  FProgression_GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Progression_GUI.ViewsProgression_GUI.Views  5   	   G(clr-namespace:Progression_GUI.ViewModelsProgression_GUI.ViewModels  5   	   ?$clr-namespace:Progression_GUI.ModelsProgression_GUI.Models  5	   	   %    Progression_GUI.Views.RunWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:Progression_GUI.Views     5   	   ?
viewmodels(clr-namespace:Progression_GUI.ViewModels     5   	   7models$clr-namespace:Progression_GUI.Models     5	   	     � Title$  	RunWindow��5   	   $	��450��6   $	��800��6(    � DataContext 5      -   'Progression_GUI.ViewModels.RunViewModel  5   
   .��5      �  � ColumnDefinitions 5   
   �� 5      $��20 �6   �� 5      $��2* �6   �� 5      $��1* �6   �� 5      $��20 �6    � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      $��* �6   �� 5      $��* �6   �� 5       $��20 �6   .+�5%   
   �� $��1��6   $��1��6"   5(      �� 5,   
   $��2��6   $��2��6"   .+�5-      � -   5        $��helmet��5-   1    � Orientation$ 
Horizontal=�6   5/      � 50      -   5        $��chest��50   1   $ 
Horizontal=�6   52      � 53      -   5        $��	main_hand��53   1   $ 
Horizontal=�6   y�6B   �� *
MainHand+55      � 56      -   5        $��off_hand��56   1   $ 
Horizontal=�6   y�6A   �� *	OffHand+58      � 59      -   5        $��two_hand��59   1   $ 
Horizontal=�6   y�6A   �� *	TwoHand+5;      � 5<      -   5        $��ring1��5<   1   $ 
Horizontal=�6   y�6>   �� *	RingOne+5>      � 5?      -   5        $��ring2��5?   1   $ 
Horizontal=�6   y�6>   �� *	RingTwo+5A      � 5B      -   5        $��gloves��5B   1   $ 
Horizontal=�6   y�6?   �� *Gloves+5D      � 5E      -	   5        $��boots��5E   1   $ 
Horizontal=�6   5G      5H      5I      5J      