package com.elfak.scrumpro.dto;

import lombok.Builder;
import lombok.Getter;
import lombok.Setter;

@Builder
@Getter
@Setter
public class UserDTO {
    private Long id;
    private String username;
    private String password;
    private String token;
}
