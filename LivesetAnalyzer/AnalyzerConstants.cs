using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LivesetAnalyzer
{
    class AnalyzerConstants
    {
        // globale Konstanten des Editors (Dateien- und Verzeichnisse)
       //public const String CR_LF = (String) System.getProperty("line.separator");
       //public const String FILE_SEPARATOR = System.getProperty("file.separator");
           public const char EXTENTION_SEPARATOR = '.' ;
           public const char FILTER_SEPARATOR = ',' ;
           //public const String WORKDIR = System.getProperty("user.dir");
           //public const Locale DEFAULTLOCALE = Locale.getDefault() ;
           public const String INIFILE = "analyzer.ini" ;
           public const String INIFILE_HEADER="Standard Editor INI-File";
           public const String LANGUAGE_FILE = "";
           public const String APPLICATION_TITLE = "Liveset Analyzer";
           //public const String PATH_LIVESET_DIRECTORY = @"N:\NIGGOS\LIVESETS";
           public const String PATH_LIVESET_DIRECTORY = @"D:\Musikmacherei\Livesets";
           public const String FILENAME_README_STANDARD = "readme.txt";
           public const String CUT_FROM_PROJECT_NAME = "Project";
           public const String ERROR_NO_LIVESET = "Not a LiveSet Folder: ";
           public const String ERR_NO_README_TEXT = "No readme text found";
           public const String PROJECT_DIR_NAME_EXTENSION = "Project";
           public const int SORT_BY_NAME = 1;
           public const int SORT_BY_LAST_MODIFIED = 2;
           public const int SORT_BY_BPM = 3;
           public const int SORT_BY_PROJECT_SIZE = 4;
   
           public const String BPM_STANDARD_WRITING = "bpm";
           public const String NO_BPM_FOUND_TEXT = "   ";
   
           public const String COMMAND_LOCK_BUTTON_PRESSED = "edit button livesetpanel pressed";
           public const String COMMAND_SAVE_BUTTON_PRESSED = "save button livesetpanel pressed";
           public const String LABEL_LOCK_BUTTON_UNLOCK = "unlock";
           public const String LABEL_LOCK_BUTTON_LOCK = "lock";
           public const String LABEL_SAVE_BUTTON = "save";
   
           public const String LABEL_SORT_BY_NAME_BUTTON = "name";
           public const String LABEL_SORT_BY_BPM_BUTTON = "bpm";
           public const String LABEL_SORT_BY_LAST_MODIFIED_BUTTON = "last modified";
           public const String LABEL_SORT_BY_PROJECT_SIZE_BUTTON = "project size";
           public const String LABEL_PREVIOUS_RESULT_BUTTON = "<<";
           public const String LABEL_NEXT_RESULT_BUTTON = ">>";
   
           public const String COMMAND_SORT_BY_NAME = "sort by name";
           public const String COMMAND_SORT_BY_BPM = "sort by bpm";
           public const String COMMAND_SORT_BY_LAST_MODIFIED = "sort by last modofied";
           public const String COMMAND_MENU_SAVE = "save the file hell yeah";
           public const String COMMAND_PREVIOUS_RESULT = "mark previous search result";
           public const String COMMAND_NEXT_RESULT = "mark next search result";
   
           public const String COMMAND_SORT_BY_PROJECT_SIZE = "sort by project size";
           public const String LABEL_MENU_FILE = "File";
           public const String LABEL_MENU_SORT = "Sort by ..";
           public const String LABEL_MENU_PREFERNCES = "Preferences";
   
           public const String LABEL_MENU_EXIT = "exit";
           public const String COMMAND_EXIT = "command exit";
   
           public const String LABEL_MENU_SORT_BY_NAME = "name";
           public const String LABEL_MENU_SORT_BY_BPM = "bpm";
           public const String LABEL_MENU_SORT_BY_LAST_MOD = "last modified";
           public const String LABEL_MENU_SORT_BY_PROJECT_SIZE = "project size";
   
           public const String COMMAND_SET_ABS_FILEPATH = "set absolute filepath";
           public const String LABEL_MENU_SET_ABS_FILEPATH = "set liveset directory";
   
        public const String DIALOG_OPTION_YES = "yes";
        public const String DIALOG_OPTION_NO = "no";
        public const String DIALOG_OPTION_CANCEL = "cancel";
   
        public const int DIALOG_SELECTION_YES = 99;
        public const int DIALOG_SELECTION_NO = 101;
        public const int DIALOG_SELECTION_CANCEL = 103;
   
        public const String LABEL_MENU_SAVE = "save readme.txt";
        public const String LABEL_SORT_BY = "sort by";

        public const String DONT_SAVE_AND_CLOSE = "dont save and close";
        public const String SAVE_AND_CLOSE =      "save and close";
        public const String CANCEL =              "cancel";
        public const int OPTION_SAC = 12;
        public const int OPTION_DSAC = 11;
        public const int OPTION_C = 10;

    }
}
