﻿using System.ComponentModel.DataAnnotations;

namespace MeetingRoom.Domain.Models
{
    public class EntitieBase<TIdentifier>
    {
        public TIdentifier Id { get; set; }
    }
}

