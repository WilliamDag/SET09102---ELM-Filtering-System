   M S B A M L   `   `   `  ����P  LELM_Filtering_Service, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:ELM_Filtering_Service.ViewsELM_Filtering_Service.Views  5      ,    &ELM_Filtering_Service.Views.AddMessage   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:ELM_Filtering_Service.Views     5      ���#EFF0F5.��5
      �   � ColumnDefinitions  5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� -   5        $��rect_Border��5      ���#E9EAEF$��10q�6:   $��3��6O   $��73��6c   $	��Top=�6o   $	��650��6�   $��Center=�6�   �� 5   
   -   5        $��rect_Header��5      ���#FCFDFF$��Center=�66   $��70��6S   $	��Top=�6_   $	��650��6w   $��3��6�   $��0,0,0.333,0q�6�   �� 5   
   -   5        $��	txt_Login��5      $��0��6@   $��2��6M   $��Right=�6]   $	��Top=�6y   $	��170��6�   $��	0 25 40 0q�6�   $��15(�6�   ���#012F4D �� TextAlignment$ Center=�6�   ��6%   �� *	TextTitle+6�   �� 5   
   -   5        $��
txt_Sender��5      $��0��6B   $��0��6O   $
��Left=�6_   $��Bottom=�6z   $��60,0,0,0q�6�   $	��100��6�   $��15(�6�   ���#012F4D$
 Left=�6�   ��6&   �� *
TextSender+6�   �� 5   
   -   5         ��Name$ 	tb_Sender��5      $��30��6E   $��0��6Q   $��Right=�6^   $��Bottom=�6z   $	��216��6�   $��1��6�   $��Center=�6�   $��Center=�6�   ��6%   �� *TextBoxSender+{�6�   �� *EnableSender+6�   �� 5   
   -   5        $��
btn_Sender��5      $��30��6p   $��0��6|   $��2��6�   $��Bottom=�6�   $
��Left=�6�   $��40 0 0 0q�6�   $	��100��6�   ���#F06060$��0q�6%  ���#E9EAEF$��2��6N  ��6#   �� *SenderButtonText+��6H   �� *SenderButtonCommand+{�6�   �� *EnableSender+6N  �� 5   
   -   5        $��txt_Subject��5      $��0��6D   $
��Left=�6T   $��	60 25 0 0q�6o   $	��Top=�6�   $	��100��6�   $��15(�6�   ���#012F4D$��1��6�   $
 Left=�6�   ��6'   �� *TextSubject+6�   �� 5   
   -   5        $ 
tb_Subject��5      $��30��6F   $��1��6R   $��Center=�6_   $	��Top=�6|    �� 	MaxLength$ 20��6�   $��0 20 0 0q�6�   $	��216��6�   $��1��6�   $��Center=�6�   $��Center=�6  ��6&   �� *TextBoxSubject+{�6�   �� *EnableSubject+6  �� 5   
   -	   5        $ tb_Body��5       �� TextWrapping$
 Wrap=�6@    �� AcceptsReturn . $��1��6i   $��Right=�6v   $	��Top=�6�   $	��359��6�   $	��221��6�   $��2��6  $��0 70 0 0q�6  $��2��6+  ��6#   �� *TextBoxBody+{�6�   �� *
EnableBody+ 6�   �� *
MessageMax+6+  �� 5   
   -
   5        $��btn_Process��5      $��1��6s   $��2��6�   $
��Left=�6�   $��Bottom=�6�   $	��100��6�   $��30��6�   ���#F06060$��0q�6  ���#E9EAEF$��	40 0 0 60q�6=  ��6$   �� *ProcessButtonText+��6J   �� *ProcessButtonCommand+{�6�   �� *
EnableBody+6=  �� 5   
   -   5        $��	btn_Clear��5      $��1��6n   $��2��6{   $
��Left=�6�   $��Bottom=�6�   $	��100��6�   $��30��6�   ���#F06060$��0q�6  ���#E9EAEF$��40 0 0 0q�68  ��6"   �� *ClearButtonText+��6F   �� *ClearButtonCommand+{�6�   �� *
EnableBody+68  �� 5    
   -   5        $��
btn_Import��5       $��2��6q   $��2��6~   $
��Left=�6�   $��Bottom=�6�   $	��100��6�   $��30��6�   ���#F06060$��0q�6  ���#E9EAEF$��
40 0 0 100q�6;  ��6#   �� *ImportButtonText+��6H   �� *ImportButtonCommand+{�6�   �� *
EnableBody+6;  5!      5"      