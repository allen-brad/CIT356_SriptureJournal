using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MyScriptureJournal.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MyScriptureJournalContext(
                serviceProvider.GetRequiredService<DbContextOptions<MyScriptureJournalContext>>()))
            {
                //look for any journal entries
                if (context.JournalEntry.Any())
                {
                    return; //DB has been seeded
                }
                context.JournalEntry.AddRange(
                    new JournalEntry
                    {
                        Book = "Omni",
                        Chapter = 1,
                        Verse = 26,
                        Note = "Am I offering my 'whole soul'?",
                        DateAdded = DateTime.Parse("2001-2-1")
                    },

                    new JournalEntry
                    {
                        Book = "Moroni",
                        Chapter = 7,
                        Verse = 48,
                        Note = "Charity is a spiritual gift. Pray for it.",
                        DateAdded = DateTime.Parse("2010-10-10")
                    },
                    new JournalEntry
                    {
                        Book = "Alma",
                        Chapter = 42,
                        Verse = 23,
                        Note = "Mercy claimeth the penitent...",
                        DateAdded = DateTime.Parse("1990-10-15")
                    },
                    new JournalEntry
                    {
                        Book = "1 Corintians",
                        Chapter = 11,
                        Verse = 11,
                        Note = "It's a sign!",
                        DateAdded = DateTime.Parse("1995-1-21")
                    },
                    new JournalEntry
                    {
                        Book = "D&C",
                        Chapter = 84,
                        Verse = 46,
                        Note = "The Spirit giveth light...",
                        DateAdded = DateTime.Parse("2001-6-10")
                    },
                    new JournalEntry
                    {
                        Book = "D&C",
                        Chapter = 64,
                        Verse = 29,
                        Note = "Be the Lord's agent",
                        DateAdded = DateTime.Parse("2018-11-15")
                    },
                    new JournalEntry
                    {
                        Book = "John",
                        Chapter = 17,
                        Verse = 5,
                        Note = "Christ references the glory he had when he was with the Father",
                        DateAdded = DateTime.Parse("2004-5-6")
                    },
                    new JournalEntry
                    {
                        Book = "Luke",
                        Chapter = 2,
                        Verse = 52,
                        Note = "Christ grows in stature and wisdom",
                        DateAdded = DateTime.Parse("1998-12-25")
                    },
                    new JournalEntry
                    {
                        Book = "Matthew",
                        Chapter = 24,
                        Verse = 44,
                        Note = "Be ready",
                        DateAdded = DateTime.Parse("1989-10-10")
                    },
                    new JournalEntry
                    {
                        Book = "1 Samuel",
                        Chapter = 17,
                        Verse = 48,
                        Note = "Be like David, run to ward the challenge",
                        DateAdded = DateTime.Parse("2018-11-15")
                    },
                    new JournalEntry
                    {
                        Book = "Moses",
                        Chapter = 1,
                        Verse = 13,
                        Note = "Moses uses the knowledge of his true identity as a source of power",
                        DateAdded = DateTime.Parse("2001-2-1")
                    },
                    new JournalEntry
                    {
                        Book = "D&C",
                        Chapter = 107,
                        Verse = 99,
                        Note = "Do your duty!",
                        DateAdded = DateTime.Parse("2000-1-1")
                    },
                    new JournalEntry
                    {
                        Book = "D&C",
                        Chapter = 20,
                        Verse = 32,
                        Note = "We can fail so we need to 'take heed also'",
                        DateAdded = DateTime.Parse("2002-2-1")
                    },
                    new JournalEntry
                    {
                        Book = "Mosiah",
                        Chapter = 2,
                        Verse = 41,
                        Note = "Happy state - hold out faithful",
                        DateAdded = DateTime.Parse("2001-2-1")
                    },
                    new JournalEntry
                    {
                        Book = "2 Nephi",
                        Chapter = 9,
                        Verse = 50,
                        Note = "Accept what the Lord is offering",
                        DateAdded = DateTime.Parse("2001-2-1")
                    },
                    new JournalEntry
                    {
                        Book = "2 Nephi",
                        Chapter = 9,
                        Verse = 39,
                        Note = "Don't be carnally-minded",
                        DateAdded = DateTime.Parse("2018-11-11")
                    },
                    new JournalEntry
                    {
                        Book = "3 Nephi",
                        Chapter = 11,
                        Verse = 11,
                        Note = "Christ's bio - I have suffered the will of the Father in all things",
                        DateAdded = DateTime.Parse("2015-8-1")
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
