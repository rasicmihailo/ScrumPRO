package com.elfak.scrumpro.DTOs;

import lombok.Builder;
import lombok.Getter;
import lombok.Setter;

@Builder
@Getter
@Setter
public class UserDTO {

    private Long id;

    private String username;
}
