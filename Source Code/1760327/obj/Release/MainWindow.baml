   M S B A M L   `   `   `  ����   1760327    _1760327.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    >d2http://schemas.microsoft.com/expression/blend/2008    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     -     � Title$  
MainWindow��$	��650��$	��800��
�������$	��700��.���  J� OpacityMask# � �� � RowDefinitions �� $��25 ��� $
��240* ��� $	��90* � � ColumnDefinitions �� $	��375 ��� $��* �.+��� $��2��$��1��$��Visible=���. $��4.8,5.2,4.6,5.4q�.���� $��0q�.+��� -    ��Name$ startButton1��$��40��$��
5,5,10.2,5q�$��1q�.����  �� Orientation$ 
Horizontal=�.+��� $��30��$��30��$)��#IconResources/press-play-button.png���� $��Start Batch��$��25(�$��2,0,0,0q�	� -    	�Name$ skip1�� 	� 	GroupName$ IsSkip�� d� 	IsChecked$
 TrueY�$��Center=�$��5q�$��Skip conflicts��	� -   $ addSuffixes1��$ IsSkip��$��Center=�$��141,0,141.2,0q�$��89��$��Add suffixes���� $��2��$��1��$��2,2.2,2.2,2.4q�.+�� $��10,5,5,5q�.+��� $��20(�
Presets:�� -   $��presetComboBox��$��2q�$	��225������ .R�� .+��� ���� *	Item.Name+�� $��: ���� ���� *Item.Args.Details+�� -   $��methodMenuOpenButton��$��3q�$��0q�.���� $$��/IconResources/open-folder.png��$��20��$��20���� -   $��methodMenuSaveButton��$��3q�$��0q�.���� $��/IconResources/save.png��$��20��$��20���� 		 �� X1$	 5��	
 �� X2$	
 365��$��3��#��� ��#��� ��� $��0��$��1��$��0,0.2,0.2,3.8q� �� $
��Auto ��� $
��Auto ��� $
��Auto ��� .+��� $�� Rename method list��$��25(�$��0��#��� ��#��� ��$��0,0,0,5q�`� -   $��methodToolBarTray��$��0,0,0,0q� `� IsLocked . $��1��.�c� .@�o� -	   $��
methodMenu��.@�m� -
   $��addMethodMenu��$��0,0,0,0q����� $ 
Horizontal=�.+��� $��20��$��20��$��/IconResources/add.png���� $��
Add method��$��20(�$��2,0,0,0q����� .R��� $��1q�
���   �$��-30,-3,-30,-3q�._��� -   $��Stretch=����� *Name+�� -   $��clearMethodMenuButton��.���� $ 
Horizontal=�.+��� $��/IconResources/clear.png��$��20��$��20���� $��5,0,0,0q�$��20(�Clear�� -   $��methodMenuTopButton��.���� $"��/IconResources/arrow-top.png��$��20��$��20���� -   $��methodMenuUpButton��.���� $!��/IconResources/arrow-up.png��$��20��$��20���� -   $��methodMenuDownButton��.���� $#��/IconResources/arrow-down.png��$��20��$��20���� -   $��methodMenuBotButton��.���� $"��/IconResources/arrow-bot.png��$��20��$��20���� $��2��$	 5��$	
 370��$��3��#��� ��#��� ���� -   $��methodListBox��$��3�� J� 	AllowDrop . $��5,0,5,0q�$��Stretch=�$��Stretch=�#��� ������ .R��  � ContextMenu �� .@�m� -   $
��Edit��.+�9� $��1q�
���   �����  �� 
TargetType" 9�.���  �� Property �@J�IsHitTestVisible �� Value .   �� Triggers ��  �� Binding �� *
IsSelected+ �� RelativeSource �� *FindAncestor+ �� AncestorType" �� �� AncestorLevel$ 1�� �� Value True.a���  �@J�IsHitTestVisible . .���� $��0,1,0,0q�
���   �$��0,5,0,0q�._��� ���� *Item.Args.Details+� $��30,0,0,0q����� " �.���  �@J�IsHitTestVisible .   ��  �� *
IsSelected+ �� *FindAncestor+" ��$ 1�� True.a���  �@J�IsHitTestVisible . .+��� $��LeftToRight=�$	��270��$��20(����� *	Item.Name+�� -   $��RightToLeft=�$��Center=�$��Center=�$��5q� �� *
IsActive+�� -   $��1q�$��RightToLeft=�$��5q�.���� $��/IconResources/delete.png��$��15��$��15���� -   $	��Tab��$��4.8,0.2,-0.4,3.8q�$��1��$��1��.@��� $��Files��.���  �� $
��Auto ��� .+�`� -   $��fileToolBarTray��$��0,0,0,0q� . $��0��.�c� $��0,0,0,0q�.@��� -   $��fileAddButton��.���� $ 
Horizontal=�.+��� $��20��$��20��$��/IconResources/add.png���� $	��Add��$��20(�$��2,0,0,0q��� -   $��fileMenuTopButton��.���� $"��/IconResources/arrow-top.png��$��20��$��20���� -   $��fileMenuUpButton��.���� $!��/IconResources/arrow-up.png��$��20��$��20���� -   $��fileMenuDownButton��.���� $#��/IconResources/arrow-down.png��$��20��$��20���� -   $��fileMenuBotButton��.���� $"��/IconResources/arrow-bot.png��$��20��$��20���� -   $��fileDeleteButton��.���� $��/IconResources/delete.png��$��20��$��20���� $
��Auto=�$
��Auto=���. $��1��.���� -   $��filesListView��$��0,0,0,0q�#��� �� �� View �� .P��� $��	File name�� �� Width$ 75�� �� CellTemplate �� .R��� ���� *Name+�� $��New file name��$ 80�� �� .R��� ���� *	NewName+�� $��	Extension��$ 60�� �� .R��� ���� *	Extension+�� $��Folder Content��$	 300�� �� .R��� ���� *	UpperPath+�� $��Error�� �� .R��� ���� *Error+�� $��Folders��.���  �� $
��Auto ��� .+�`� -   $��folderToolBarTray��$��0,0,0,0q� . $��0��.�c� .@��� -   $��folderAddButton��.���� $ 
Horizontal=�.+��� $��20��$��20��$��/IconResources/add.png���� $	��Add��$��20(�$��2,0,0,0q��� -    $��folderMenuTopButton��.���� $"��/IconResources/arrow-top.png��$��20��$��20���� -!   $��folderMenuUpButton��.���� $!��/IconResources/arrow-up.png��$��20��$��20���� -"   $��folderMenuDownButton��.���� $#��/IconResources/arrow-down.png��$��20��$��20���� -#   $��folderMenuBotButton��.���� $"��/IconResources/arrow-bot.png��$��20��$��20���� -$   $��folderDeleteButton��.���� $��/IconResources/delete.png��$��20��$��20���� $
��Auto=�$
��Auto=���. $��1��.���� -%   $��folderListView��$��0,0,0,0q�#��� �� �� $��Visible=�.P��� $��Folder name��$ 75�� �� .R��� ���� *Name+�� $��New Folder name��$	 100�� �� .R��� ���� *	NewName+�� $��Folder Content��$	 300�� �� .R��� ���� *	UpperPath+�� $��Error�� �� .R��� ���� *Error+