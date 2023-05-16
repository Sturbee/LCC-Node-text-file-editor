# LCC-Node-text-file-editor
Reads a CDI backup text file and edit then save the text file for CDI restore.

Program reads a JMRI LCC Node CDI text file created by the backup function and outputs to a xml file.
  Each line of the text file is read and compared to the the tables in the ImportCDI.xml file.
  First start of each text line is compared to the text in the MachLevel1 table, if match is found then the segment is known
    The text input line is reduced by the matching text.
  Next the remaining text input line is compared to the text in the MatchLevel2 table, if match is found then the export table is known
    and the text input line is reduced.
  This is repeated for MatchLevel3 and MatchLevel4 tables. Currently there is no more matching to be done after Level4.
  After all text input lines have been processed, a xml is created with the name of the text file and file extension .xml.
  
  Next the program writes the edits back to the text file for doing a restore from the JMRI LCC Node CDI. At this point the LCC Node has been changed.
